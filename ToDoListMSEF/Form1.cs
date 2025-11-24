using Microsoft.EntityFrameworkCore;
namespace ToDoListMSEF
{
    public partial class Form1 : Form
    {
        Database db = new Database();
        //List<ToDoItem> items;
        public Form1()
        {
            InitializeComponent();
            //sprawdzamy czy baza istnieje, jeœli nie to j¹ tworzymy
            db.Database.EnsureCreated();
            //³adowanie danych z bazy do lokalnej pamiêci
            db.ToDoItems.Load();
            ToDoBindingSource.DataSource = db.ToDoItems.Local.ToBindingList();
            ToDoDataGridView.DataSource = ToDoBindingSource;
            ////pobieramy sobie wszystkie zadania z bazy danych
            //items = db.ToDoItems.ToList();
            ////tworzymy databinding Ÿród³o danych dla DataGridView
            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = items;
            ////ustawiamy Ÿród³o danych dla DataGridView
            //ToDoDataGridView.DataSource = bindingSource;
            //kosmetyka - ukrywamy kolumnê Id i dostosowujemy szerokoœæ kolumn
            if (ToDoDataGridView.Columns["Id"] != null)
                ToDoDataGridView.Columns["Id"].Visible = false;
            //dodaj kolumnê z guzikiem do usuwania zadañ
            //definiujemy kolumnê
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            //ustawiamy jej w³aœciwoœci
            //nazwa kolumny w DataGridView
            deleteButtonColumn.Name = "Remove";
            //tekst nag³ówka kolumny
            deleteButtonColumn.HeaderText = "Usuñ zadanie";
            //tekst na guziku
            deleteButtonColumn.Text = "Usuñ";
            //tekst taki sam dla ka¿dego guzika
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            //dodajemy kolumnê do DataGridView
            ToDoDataGridView.Columns.Add(deleteButtonColumn);

            ToDoDataGridView.AutoResizeColumns();
        }
        // ta funkcja jest przypiêta do zdarzenia FormClosed formularza
        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            //sprz¹tamy wykonane zadania z terminem w przesz³oœci
            //usuñ wszystkie wiersze gdzie isCompleted jest true i DueDate jest mniejsze ni¿ teraz
            var completedItems = db.ToDoItems
                                   .Where(item => item.IsCompleted && item.DueDate < DateTime.Now);
            db.ToDoItems.RemoveRange(completedItems);
            db.SaveChanges();
            //zamykanie po³¹czenia z baz¹ danych przy zamykaniu formularza
            db.Dispose();
        }

        private void AddToDoButton_Click(object sender, EventArgs e)
        {
            //pobiermay nazwê zadania z textboxa
            string name = ToDoNameTextBox.Text;
            //sprawdzamy czy nazwa nie jest pusta
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Nazwa zadania nie mo¿e byæ pusta.", "B³¹d",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                //reszta funkcji nie jest wykonywana
                return;
            }
            //pobieramy datê wykonania z DateTimePickera
            DateTime dueDate = ToDoDateTimePicker.Value;
            //tworzymy nowe zadanie
            ToDoItem newItem = new ToDoItem();
            //nadajemy mu nazwe, datê utworzenia i datê wykonania
            newItem.Name = name;
            newItem.CreatedAt = DateTime.Now;
            newItem.DueDate = dueDate;
            newItem.IsCompleted = false;
            //dodajemy zadanie do bazy
            db.ToDoItems.Add(newItem);
            //zapisujemy zmiany w bazie
            db.SaveChanges();
            //czyœcimy textboxa
            ToDoNameTextBox.Text = "";
            ////prze³aduj dane w DataGridView
            //items = db.ToDoItems.ToList();
            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = items;
            //ToDoDataGridView.DataSource = bindingSource;
        }

        private void ToDoDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //upewnij siê, ¿e zmiany w DataGridView s¹ zatwierdzone
            ToDoDataGridView.EndEdit();
            //zatwierdŸ zmiany w Ÿródle danych
            ToDoBindingSource.EndEdit();
            //zapisz zmiany do bazy danych
            db.SaveChanges();
            //// sprawdŸ czy w ogóle kikniêto "poprawny" wiersz
            //if (e.RowIndex >= 0)
            //{
            //    //pobierz ca³y wiersz z dataGridView (wiersz tabeli)
            //    var row = ToDoDataGridView.Rows[e.RowIndex];
            //    //wyci¹gnij sobie ID z wiersza - to jest to samo ID co w bazie danych
            //    int id = (int)row.Cells["Id"].Value;

            //    // ZnajdŸ oryginalny obiekt w bazie danych - aktualizujemy bazê, a nie listê w pamiêci
            //    var item = db.ToDoItems.FirstOrDefault(x => x.Id == id);
            //    if (item != null)
            //    {
            //        // Zaktualizuj w³aœciwoœci na podstawie wartoœci z DataGridView
            //        item.Name = row.Cells["Name"].Value?.ToString();
            //        item.DueDate = Convert.ToDateTime(row.Cells["DueDate"].Value);
            //        item.IsCompleted = Convert.ToBoolean(row.Cells["IsCompleted"].Value);
            //        // Mo¿esz dodaæ inne w³aœciwoœci jeœli s¹ edytowalne
            //    }
            //    db.SaveChanges();
            //}
        }

        private void ToDoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //je¿eli nazwa obecnie "rysowanej" kolumny to DueDate
            if (ToDoDataGridView.Columns[e.ColumnIndex].Name == "DueDate")
            {
                //zak³adamy, ¿e nigdy nie bêdziemy mieli pustej daty
                string dueDateString = e.Value.ToString();
                //konwertujemy na DateTime ze stringa
                DateTime dueDate = DateTime.Parse(dueDateString);
                if (dueDate < DateTime.Now)
                {
                    //ustaw kolor t³a obecnego wiersza na czerwony
                    ToDoDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void ToDoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //sprawdzamy czy klikniêto w kolumnê z guzikami
            if (ToDoDataGridView.Columns[e.ColumnIndex].Name == "Remove")
            {
                //wyci¹gnij obiekt powi¹zany z danym wierszem
                var rowData = ToDoDataGridView.Rows[e.RowIndex].DataBoundItem;
                //usuñ ten obiekt z bazy danych
                db.ToDoItems.Remove((ToDoItem)rowData);
                //zapisz zmiany w bazie danych
                db.SaveChanges();
            }
        }
    }
}

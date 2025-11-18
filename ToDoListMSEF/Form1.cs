namespace ToDoListMSEF
{
    public partial class Form1 : Form
    {
        Database db = new Database();
        List<ToDoItem> items;
        public Form1()
        {
            InitializeComponent();
            //sprawdzamy czy baza istnieje, jeœli nie to j¹ tworzymy
            db.Database.EnsureCreated();
            //pobieramy sobie wszystkie zadania z bazy danych
            items = db.ToDoItems.ToList();
            //tworzymy databinding Ÿród³o danych dla DataGridView
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = items;
            //ustawiamy Ÿród³o danych dla DataGridView
            ToDoDataGridView.DataSource = bindingSource;
            //kosmetyka - ukrywamy kolumnê Id i dostosowujemy szerokoœæ kolumn
            ToDoDataGridView.Columns["Id"].Visible = false;
            ToDoDataGridView.AutoResizeColumns();
        }
        // ta funkcja jest przypiêta do zdarzenia FormClosed formularza
        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            //zamykanie po³¹czenia z baz¹ danych przy zamykaniu formularza
            db.Dispose();
        }

        private void AddToDoButton_Click(object sender, EventArgs e)
        {
            //pobiermay nazwê zadania z textboxa
            string name = ToDoNameTextBox.Text;
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
            //wyœwietlamy komunikat
            MessageBox.Show("Zadanie dodane pomyœlnie!");
        }

        private void ToDoDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // sprawdŸ czy w ogóle kikniêto "poprawny" wiersz
            if (e.RowIndex >= 0)
            {
                //pobierz ca³y wiersz z dataGridView (wiersz tabeli)
                var row = ToDoDataGridView.Rows[e.RowIndex];
                //wyci¹gnij sobie ID z wiersza - to jest to samo ID co w bazie danych
                int id = (int)row.Cells["Id"].Value;

                // ZnajdŸ oryginalny obiekt w bazie danych - aktualizujemy bazê, a nie listê w pamiêci
                var item = db.ToDoItems.FirstOrDefault(x => x.Id == id);
                if (item != null)
                {
                    // Zaktualizuj w³aœciwoœci na podstawie wartoœci z DataGridView
                    item.Name = row.Cells["Name"].Value?.ToString();
                    item.DueDate = Convert.ToDateTime(row.Cells["DueDate"].Value);
                    item.IsCompleted = Convert.ToBoolean(row.Cells["IsCompleted"].Value);
                    // Mo¿esz dodaæ inne w³aœciwoœci jeœli s¹ edytowalne
                }
                db.SaveChanges();
            }
        }
    }
}

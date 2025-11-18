namespace ToDoListMSEF
{
    public partial class Form1 : Form
    {
        Database db = new Database();
        public Form1()
        {
            InitializeComponent();
            //inicjujemy obiekt dostêpu do bazy danych
            Database db = new Database();
            //sprawdzamy czy baza istnieje, jeœli nie to j¹ tworzymy
            db.Database.EnsureCreated();
            //pobieramy sobie wszystkie zadania z bazy danych
            List<ToDoItem> items = db.ToDoItems.ToList();
            //tworzymy databinding Ÿród³o danych dla DataGridView
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = items;
            //ustawiamy Ÿród³o danych dla DataGridView
            ToDoDataGridView.DataSource = bindingSource;
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
    }
}

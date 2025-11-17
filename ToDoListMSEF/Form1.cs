namespace ToDoListMSEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddToDoButton_Click(object sender, EventArgs e)
        {
            //pobiermay nazwê zadania z textboxa
            string name = ToDoNameTextBox.Text;
            //pobieramy datê wykonania z DateTimePickera
            DateTime dueDate = ToDoDateTimePicker.Value;
            //tworzymy obiekt dostêpu do bazy danych
            Database db = new Database();
            //sprawdzamy czy baza istnieje, jeœli nie to j¹ tworzymy
            db.Database.EnsureCreated();
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

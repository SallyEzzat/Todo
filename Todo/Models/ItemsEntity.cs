//Sally: Added 9 April,2019 
using SQLite;  namespace Todo {
    //Creating a class to get and set the data of each Todo Item in the application
    public class ItemsEntity
    {
        //The ID property is marked with PrimaryKey and AutoIncrement attributes to ensure that each Todo Item in the SQLite.NET database will have a unique id.
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //The Name property is a string definig the name of each Todo Item in the application
        public string Name { get; set; }
        //The Done property is a boolean definig if the Todo Item is marked as Done or not
        public bool Done { get; set; }
    } }  

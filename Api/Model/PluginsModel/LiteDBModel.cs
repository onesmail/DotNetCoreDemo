﻿namespace Api.Model.PluginsModel
{
    public class LiteDBModel
    {

    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }
}

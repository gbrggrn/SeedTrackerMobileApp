using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedTracker.Models
{
    public class Seed
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SeedName { get; set; }
        public DateTime SowingDate { get; set; }
        public string Species { get; set; }
        public string Notes { get; set; }
    }
}

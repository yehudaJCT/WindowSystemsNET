using System.ComponentModel.DataAnnotations;
using WindowSystems.DL.SQL.model;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.model
{
    public class DBlink
    {
        [Key]
        public int id { get; set; }

        public int MapId { get; set; }
        public int LocationId { get; set; }
        public int WeatherId { get; set; }
        public int ChatGptId { get; set; }


        DBlink() { }

    }
}

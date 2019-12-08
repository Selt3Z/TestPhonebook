using SQLite;

namespace App3
{
    [Table("Coworkers")]
    public class Coworker
    {
        [Column("name.first")]
        public string FirstName { get; set; }
        [Column("name.last")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("picture.large")]
        public string PhotoLarge { get; set; }
        [Column("picture.medium")]
        public string PhotoMedium { get; set; }
        [Column("picture.thumbnail")]
        public string PhotoThumbnail { get; set; }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leaf.Core.Domain.Spreads
{
    public partial class Qichacha
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string LinkMan { get; set; }

        [StringLength(30)]
        public string FundDate { get; set; }

        public int? FundDay { get; set; }

        [StringLength(64)]
        public string RegCapitalStr { get; set; }

        [StringLength(255)]
        public string ActWorkAddr { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string LinkPhone { get; set; }

        [StringLength(1024)]
        public string ActScope { get; set; }

        [StringLength(255)]
        public string WebSiteUrl { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Valid { get; set; }
    }
}

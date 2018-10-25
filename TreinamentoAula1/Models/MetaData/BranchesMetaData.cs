using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinamentoAula1.Models.MetaData
{
    public class BranchesMetaData
    {

        [Display(Name = "nameBranch", ResourceType = typeof(Resources.Strings))]
        [Required(ErrorMessageResourceType = typeof(Resources.Strings), ErrorMessageResourceName = "required")]
        public string name { get; set; }

        [Display(Name = "descriptionBranch", ResourceType = typeof(Resources.Strings))]
        [Required(ErrorMessageResourceType = typeof(Resources.Strings), ErrorMessageResourceName = "required")]
        public int description { get; set; }

        [Display(Name = "mergeExecuted", ResourceType = typeof(Resources.Strings))]
        public bool merge_executed { get; set; }

        [Display(Name = "parentBranch", ResourceType = typeof(Resources.Strings))]
        [Required(ErrorMessageResourceType = typeof(Resources.Strings), ErrorMessageResourceName = "required")]
        public int parent_branch { get; set; }

        public int type { get; set; }

        [Display(Name = "product", ResourceType = typeof(Resources.Strings))]
        [Required(ErrorMessageResourceType = typeof(Resources.Strings), ErrorMessageResourceName = "required")]
        public int product { get; set; }

        public int id { get; set; }
    }
}
using DataBindable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class SystemId : ValidatableBindableBase, Identity
    {
        public SystemId()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        private long id;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
                
        private bool deleted;
        public bool Deleted
        {
            get => deleted;
            set => SetProperty(ref deleted, value);
        }

        private bool disabled;
        public bool Disabled
        {
            get => disabled;
            set => SetProperty(ref disabled, value);
        }

        private bool fromSystem;
        public bool FromSystem
        {
            get => fromSystem;
            set => SetProperty(ref fromSystem, value);
        }

        private DateTime createdDate;
        public DateTime CreatedDate
        {
            get => createdDate;
            set => SetProperty(ref createdDate, value);
        }

        private DateTime updatedDate;
        public DateTime UpdatedDate
        {
            get => updatedDate;
            set => SetProperty(ref updatedDate, value);
        }

        private bool hasError;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool HasError
        {
            get => hasError;
            set => SetProperty(ref hasError, value);
        }

        private string error;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);
        }

        
    }

}

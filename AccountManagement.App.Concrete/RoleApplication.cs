using _0_Framework.App;
using AccountManagement.App.Role;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.App.Concrete
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;
        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public OperationResult Create(CreateRole createRole)
        {
            var operation = new OperationResult();

            if (_roleRepository.Exist(x => x.Name == createRole.Name))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var role = new AccountManagement.Domain.RoleAgg.Role(createRole.Name);

            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRole editRole)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(editRole.ID);

            if (role == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }
            if (_roleRepository.Exist(x => x.Name == editRole.Name && x.ID != editRole.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            role.Edit(editRole.Name);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditRole GetDetails(int Id)
        {
            return _roleRepository.GetDetails(Id);
        }

        public List<RoleViewModel> ListOfRoles()
        {
            return _roleRepository.ListOfRoles();
        }
    }
}

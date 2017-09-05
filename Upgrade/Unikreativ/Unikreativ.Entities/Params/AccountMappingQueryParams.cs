using System;
using System.Collections.Generic;
using System.Text;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Entities.Params
{
    public class AccountMappingQueryParams
    {
        public Client ClientDto { get; set; }
        public Member MemberDto { get; set; }
    }
}
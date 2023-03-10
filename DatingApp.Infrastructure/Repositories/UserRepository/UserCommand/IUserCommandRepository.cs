﻿using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Repositories.UserRepository.UserCommand
{
    public interface IUserCommandRepository : ICommandRepository<AppUser>
    {
    }
}

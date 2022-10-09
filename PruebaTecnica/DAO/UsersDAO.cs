using Microsoft.Extensions.Logging;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace PruebaTecnica.DAO
{
    public class UsersDAO
    {
        public UserResponse CreateUser(UserRequest userRequest)
        {
            var userResponse = new UserResponse();

            try
            {
                using (PruebaTecnicaEntities context = new PruebaTecnicaEntities())
                {
                    var user = context.CreateUser(userRequest.FirstName, userRequest.LastName, userRequest.BirthDate.ToString("yyyy-MM-dd"), userRequest.Email, userRequest.PhoneNumber).FirstOrDefault(u => true);
                    
                    if (user != null)
                    {
                        userResponse = UserResponse.FromEntity(user);
                    }
                }
            }
            catch (Exception e)
            {
                userResponse = null;
            }

            return userResponse;
        }

        public UserResponse UpdateUser(long idUser, UserRequest userRequest)
        {
            var userResponse = new UserResponse();

            try
            {
                using (PruebaTecnicaEntities context = new PruebaTecnicaEntities())
                {
                    var user = context.UpdateUser(idUser, userRequest.FirstName, userRequest.LastName, userRequest.BirthDate.ToString("yyyy-MM-dd"), userRequest.Email, userRequest.PhoneNumber).FirstOrDefault(u => true);

                    if (user != null)
                    {
                        userResponse = UserResponse.FromEntity(user);
                    }
                }
            }
            catch (Exception e)
            {
                userResponse = null;
            }

            return userResponse;
        }

        public UserResponse DeleteUser(long idUser)
        {
            var userResponse = new UserResponse();

            try
            {
                using (PruebaTecnicaEntities context = new PruebaTecnicaEntities())
                {
                    var user = context.DeleteUserById(idUser).FirstOrDefault(u => true);

                    if (user != null)
                    {
                        userResponse = UserResponse.FromEntity(user);
                    }
                }
            }
            catch (Exception e)
            {
                userResponse = null;
            }

            return userResponse;
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            var users = new List<UserResponse>();

            try
            {
                using (PruebaTecnicaEntities context = new PruebaTecnicaEntities())
                {
                    var userEntities = context.GetUsersByActive(true);

                    foreach (User u in userEntities)
                    {
                        users.Add(UserResponse.FromEntity(u));
                    }
                }
            }
            catch (Exception e)
            {
                users = null;
            }

            return users;
        }

        public UserResponse GetUser(long idUser)
        {
            var userResponse = new UserResponse();

            try
            {
                using (PruebaTecnicaEntities context = new PruebaTecnicaEntities())
                {
                    var userEntities = context.GetUserById(idUser);

                    foreach (User u in userEntities)
                    {
                        userResponse = UserResponse.FromEntity(u);
                    }
                }
            }
            catch (Exception e)
            {
                userResponse = null;
            }

            return userResponse;
        }
    }
}
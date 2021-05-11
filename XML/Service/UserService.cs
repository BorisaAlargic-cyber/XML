using System;
using System.Collections.Generic;
using XML.Model;
using XML.Repository;

namespace XML.Service
{
    public class UserService
    {
        public UserService()
        {
        }

        public User Register(User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    User dbUser = unitOfWork.Users.GetUserWithEmail(user.Email);

                    if (dbUser != null)
                    {
                        return null;
                    }

                    dbUser = new User();
                    dbUser.Email = user.Email;
                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.Username = user.Username;
                    dbUser.WebSite = user.WebSite;
                    dbUser.PhoneNumber = user.PhoneNumber;
                    dbUser.dateOfBirth = user.dateOfBirth;
                    dbUser.Deleted = false;
                    dbUser.IsPrivate = user.IsPrivate;
                    dbUser.Gender = user.Gender;

                    unitOfWork.Users.Add(user);
                    unitOfWork.Complete();

                    return dbUser;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> GetPublicProfiles(string search)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    return unitOfWork.Users.GetPublicProfiles(search);
                }
            }
            catch (Exception e)
            {
                return new List<User>();
            }
        }
    }
}

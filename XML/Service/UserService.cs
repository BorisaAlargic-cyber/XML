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

        public CloseFriends AddToCloseFriends(User currentUser,int closeFriendId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    CloseFriends closeFriends = new CloseFriends();
                    User user = unitOfWork.Users.Get(closeFriendId);

                    closeFriends.Owner = currentUser;
                    closeFriends.CloseFriend = user;
                    closeFriends.IsCloseFriend = true;

                    unitOfWork.CloseFriends.Update(closeFriends);
                    unitOfWork.Complete();

                    return closeFriends;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public CloseFriends RemoveFromCloseFriends( int closeFriendId)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    CloseFriends closeFriends = unitOfWork.CloseFriends.Get(closeFriendId);

                    closeFriends.IsCloseFriend = false;

                    unitOfWork.CloseFriends.Update(closeFriends);
                    unitOfWork.Complete();

                    return closeFriends;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public User EditProfile(User user)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    User dbUser = unitOfWork.Users.GetUserWithEmail(user.Email);

                    dbUser.Email = user.Email;
                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.Gender = user.Gender;
                    dbUser.PhoneNumber = user.PhoneNumber;
                    dbUser.WebSite = user.WebSite;
                    dbUser.PhoneNumber = user.PhoneNumber;
                    dbUser.dateOfBirth = user.dateOfBirth;
                    dbUser.IsPrivate = user.IsPrivate;

                    unitOfWork.Users.Update(dbUser);
                    unitOfWork.Complete();

                    return dbUser;
                }
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}

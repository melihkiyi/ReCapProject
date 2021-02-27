using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<IEntity, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cus in context.Customers
                             on r.CustomerId equals cus.CustomerId
                             join us in context.Users
                             on cus.UserId equals us.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = cus.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}

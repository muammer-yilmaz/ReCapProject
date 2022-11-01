using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, ReCapContext>, ICreditCardDal
    {
        public CreditCard MatchCard(CreditCard creditCard)
        {
            using ReCapContext context = new ReCapContext();

            var result = (from c in context.CreditCards
                          where c.CardNumber == creditCard.CardNumber
                          && c.ExpirationMonth == creditCard.ExpirationMonth
                          && c.ExpirationYear == creditCard.ExpirationYear
                          && c.Cvv == creditCard.Cvv
                          select c).FirstOrDefault();
            return result;
        }

        public bool UpdateBalance(int cardId, decimal newBalance)
        {
            using ReCapContext context = new ReCapContext();

            //var result = (from c in context.CreditCards
            //              where c.Id == cardId
            //              select c).FirstOrDefault();
            //if(result is null)
            //{
            //    return false;
            //}
            var card = context.CreditCards.Find(cardId);
            if (card is null)
            {
                return false;
            }
            card.Balance = newBalance;
            context.Entry(card).Property("Balance").IsModified = true;
            context.SaveChanges();
            return true;
        }
    }
}

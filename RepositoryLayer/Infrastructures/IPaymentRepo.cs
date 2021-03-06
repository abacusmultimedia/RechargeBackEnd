using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payment;

namespace RepositoryLayer.Infrastructures
{
    public interface IPaymentRepo: IRepositoryBase<RC_Payment>
    {
        IEnumerable<PaymentDTO> GetAll();
        PaymentDTO GetbyId(long id);
        Task Post(PaymentDTO model);
        void Put(PaymentDTO model);
        void SoftDelete(long id);
    }
}

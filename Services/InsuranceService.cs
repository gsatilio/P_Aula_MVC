using Models;
using Repositories;

namespace Services
{
    public class InsuranceService
    {
        private InsuranceRepository _insuranceRepository;
        public InsuranceService()
        {
            _insuranceRepository = new InsuranceRepository();
        }
        public int Insert(Insurance insurance)
        {
            Console.WriteLine("Camada Service");
            return _insuranceRepository.Insert(insurance);
        }
    }
}

using ApiDatiAnagrafici.Models;
using DatiAnagrafici.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDatiAnagrafici.Messages
{
    public class AddDatiRequest
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public DateTime DataDiNascita { get; set; }

    }

    public class AddDatiResponse : BaseResponse
    {

    }

    public class GetAllDatiRequest
    {
        public string Search { get; set; }
    }

    public class GetAllDatiResponse : BaseResponse
    {
        public IEnumerable<GetDatiAnagraficiModel> Dati { get; set; }
    }


    public class GetDatiByIdRequest
    {
        public int Id { get; set; }
    }

    public class GetDatiByIdResponse : BaseResponse
    {
        public GetDatiAnagraficiModel Dati { get; set; }
    }


    public class EditDatiRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public DateTime DataDiNascita { get; set; }
    }

    public class EditDatiResponse : BaseResponse
    {

    }

    public class RemoveDatiRequest
    {
        public int Id { get; set; }
    }

    public class RemoveDatiResponse : BaseResponse
    {

    }
}

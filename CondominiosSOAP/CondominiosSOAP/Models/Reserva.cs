using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CondominiosSOAP.Models
{
    [DataContract]
    public class Reserva
    {
        [DataMember]
        public string FechaReserva { get; set; }
        [DataMember]
        public string HoraInicio { get; set; }
        [DataMember]
        public string HoraFin { get; set; }
        [DataMember]
        public int IdAreaComun { get; set; }
        [DataMember]
        public int IdInquilino { get; set; }
        [DataMember]
        public int usuariocreacion { get; set; }
        [DataMember]
        public string fechacreacion { get; set; }

    }
}
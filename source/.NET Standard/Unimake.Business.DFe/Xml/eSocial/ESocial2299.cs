﻿#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Utility;

namespace Unimake.Business.DFe.Xml.ESocial
{
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.ESocial2299")]
    [ComVisible(true)]
#endif
    [Serializable()]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtDeslig/v_S_01_02_00", IsNullable = false)]
    public class ESocial2299 : XMLBase
    {
        [XmlElement("evtDeslig")]
        public EvtDeslig EvtDeslig { get; set; }

        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.EvtDeslig")]
    [ComVisible(true)]
#endif
    public class EvtDeslig
    {
        [XmlAttribute(AttributeName = "Id", DataType = "token")]
        public string ID { get; set; }

        [XmlElement("ideEvento")]
        public IdeEvento2299 IdeEvento { get; set; }

        [XmlElement("ideEmpregador")]
        public IdeEmpregador IdeEmpregador { get; set; }

        [XmlElement("ideVinculo")]
        public IdeVinculo IdeVinculo { get; set; }

        [XmlElement("infoDeslig")]
        public InfoDeslig InfoDeslig { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.IdeEvento2299")]
    [ComVisible(true)]
#endif
    public class IdeEvento2299
    {
        [XmlElement("indRetif")]
        public IndicativoRetificacao IndRetif { get; set; }

        [XmlElement("nrRecibo")]
        public string NrRecibo { get; set; }

        [XmlElement("indGuia")]
        public string IndGuia { get; set; }

        [XmlElement("tpAmb")]
        public TipoAmbiente TpAmb { get; set; }

        [XmlElement("procEmi")]
        public ProcEmiESocial ProcEmi { get; set; }

        [XmlElement("verProc")]
        public string VerProc { get; set; }

        #region ShouldSerialize

        public bool ShouldSerializeNrRecibo() => !string.IsNullOrEmpty(NrRecibo);

        public bool ShouldSerializeIndGuia() => !string.IsNullOrEmpty(IndGuia);

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoDeslig")]
    [ComVisible(true)]
#endif
    public class InfoDeslig
    {
        [XmlElement("mtvDeslig")]
        public string MtvDeslig { get; set; }

        [XmlIgnore]
#if INTEROP
        public DateTime DtDeslig { get; set; }
#else
        public DateTimeOffset DtDeslig { get; set; }
#endif

        [XmlElement("dtDeslig")]
        public string DtDesligField
        {
            get => DtDeslig.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtDeslig = DateTime.Parse(value);
#else
            set => DtDeslig = DateTimeOffset.Parse(value);
#endif
        }

        [XmlIgnore]
#if INTEROP
        public DateTime DtAvPrv { get; set; }
#else
        public DateTimeOffset DtAvPrv { get; set; }
#endif

        [XmlElement("dtAvPrv")]
        public string DtAvPrvField
        {
            get => DtAvPrv.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtAvPrv = DateTime.Parse(value);
#else
            set => DtAvPrv = DateTimeOffset.Parse(value);
#endif
        }

        [XmlElement("indPagtoAPI")]
        public SimNaoLetra IndPagtoAPI { get; set; }

        [XmlIgnore]
#if INTEROP
        public DateTime DtProjFimAPI { get; set; }
#else
        public DateTimeOffset DtProjFimAPI { get; set; }
#endif

        [XmlElement("dtProjFimAPI")]
        public string DtProjFimAPIField
        {
            get => DtProjFimAPI.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtProjFimAPI = DateTime.Parse(value);
#else
            set => DtProjFimAPI = DateTimeOffset.Parse(value);
#endif
        }

        [XmlElement("pensAlim")]
#if INTEROP
        public PensAlim PensAlim { get; set; } = (PensAlim)(-1);
#else
        public PensAlim? PensAlim { get; set; }
#endif

        [XmlElement("percAliment")]
        public int PercAliment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public double VrAlim { get; set; }
        [XmlElement("vrAlim")]
        public string VrAlimField
        {
            get => VrAlim.ToString("F2", CultureInfo.InvariantCulture);
            set => VrAlim = Converter.ToDouble(value);
        }

        #region ShouldSerialize

        public bool ShouldSerializeVrAlimField() => VrAlim > 0;

        #endregion ShouldSerialize

        [XmlElement("nrProcTrab")]
        public string NrProcTrab { get; set; }

        [XmlElement("indPDV")]
        public string IndPDV { get; set; }

        [XmlElement("infoInterm")]
        public List<InfoInterm> InfoInterm { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddInfoInterm(InfoInterm item)
        {
            if (InfoInterm == null)
            {
                InfoInterm = new List<InfoInterm>();
            }

            InfoInterm.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista InfoInterm (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da InfoInterm</returns>
        public InfoInterm GetInfoInterm(int index)
        {
            if ((InfoInterm?.Count ?? 0) == 0)
            {
                return default;
            };

            return InfoInterm[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista InfoInterm
        /// </summary>
        public int GetInfoIntermCount => (InfoInterm != null ? InfoInterm.Count : 0);
#endif

        [XmlElement("observacoes")]
        public List<Observacoes> Observacoes { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddObservacoes(Observacoes item)
        {
            if (Observacoes == null)
            {
                Observacoes = new List<Observacoes>();
            }

            Observacoes.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista Observacoes (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da Observacoes</returns>
        public Observacoes GetObservacoes(int index)
        {
            if ((Observacoes?.Count ?? 0) == 0)
            {
                return default;
            };

            return Observacoes[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista Observacoes
        /// </summary>
        public int GetObservacoesCount => (Observacoes != null ? Observacoes.Count : 0);
#endif

        [XmlElement("sucessaoVinc")]
        public SucessaoVinc2299 SucessaoVinc { get; set; }

        [XmlElement("transfTit")]
        public TransfTit TransfTit { get; set; }

        [XmlElement("mudancaCPF")]
        public MudancaCPF2299 MudancaCPF { get; set; }

        [XmlElement("verbasResc")]
        public VerbasResc VerbasResc { get; set; }

        [XmlElement("remunAposDeslig")]
        public RemunAposDeslig RemunAposDeslig { get; set; }

        [XmlElement("consigFGTS")]
        public List<ConsigFGTS> ConsigFGTS { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddConsigFGTS(ConsigFGTS item)
        {
            if (ConsigFGTS == null)
            {
                ConsigFGTS = new List<ConsigFGTS>();
            }

            ConsigFGTS.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista ConsigFGTS (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da ConsigFGTS</returns>
        public ConsigFGTS GetConsigFGTS(int index)
        {
            if ((ConsigFGTS?.Count ?? 0) == 0)
            {
                return default;
            };

            return ConsigFGTS[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista ConsigFGTS
        /// </summary>
        public int GetConsigFGTSCount => (ConsigFGTS != null ? ConsigFGTS.Count : 0);
#endif

        #region ShouldSerialize

        public bool ShouldSerializeDtAvPrvField() => DtAvPrv > DateTime.MinValue;

        public bool ShouldSerializeDtProjFimAPIField() => DtProjFimAPI > DateTime.MinValue;

#if INTEROP
        public bool ShouldSerializePensAlim() => PensAlim != (PensAlim)(-1);
#else
        public bool ShouldSerializePensAlim() => PensAlim != null;
#endif

        public bool ShouldSerializePercAliment() => PercAliment > 0;

        public bool ShouldSerializeVrAlim() => VrAlim > 0;

        public bool ShouldSerializeNrProcTrab() => !string.IsNullOrEmpty(NrProcTrab);

        public bool ShouldSerializeIndPDV() => !string.IsNullOrEmpty(IndPDV);

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.SucessaoVinc2299")]
    [ComVisible(true)]
#endif
    public class SucessaoVinc2299
    {
        [XmlElement("tpInsc")]
        public TiposInscricao TpInsc { get; set; }

        [XmlElement("nrInsc")]
        public string NrInsc { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.TransfTit")]
    [ComVisible(true)]
#endif
    public class TransfTit
    {
        [XmlElement("cpfSubstituto")]
        public string CpfSubstituto { get; set; }

        [XmlIgnore]
#if INTEROP
        public DateTime DtNascto { get; set; }
#else
        public DateTimeOffset DtNascto { get; set; }
#endif

        [XmlElement("dtNascto")]
        public string DtNasctoField
        {
            get => DtNascto.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtNascto = DateTime.Parse(value);
#else
            set => DtNascto = DateTimeOffset.Parse(value);
#endif
        }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.MudancaCPF2299")]
    [ComVisible(true)]
#endif
    public class MudancaCPF2299
    {
        [XmlElement("novoCPF")]
        public string NovoCPF { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.VerbasResc")]
    [ComVisible(true)]
#endif
    public class VerbasResc
    {
        [XmlElement("dmDev")]
        public List<DmDev2299> DmDev { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddDmDev(DmDev2299 item)
        {
            if (DmDev == null)
            {
                DmDev = new List<DmDev2299>();
            }

            DmDev.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista DmDev (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da DmDev</returns>
        public DmDev2299 GetDmDev(int index)
        {
            if ((DmDev?.Count ?? 0) == 0)
            {
                return default;
            };

            return DmDev[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista DmDev
        /// </summary>
        public int GetDmDevCount => (DmDev != null ? DmDev.Count : 0);
#endif

        [XmlElement("procJudTrab")]
        public List<ProcJudTrab> ProcJudTrab { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddProcJudTrab(ProcJudTrab item)
        {
            if (ProcJudTrab == null)
            {
                ProcJudTrab = new List<ProcJudTrab>();
            }

            ProcJudTrab.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista ProcJudTrab (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da ProcJudTrab</returns>
        public ProcJudTrab GetProcJudTrab(int index)
        {
            if ((ProcJudTrab?.Count ?? 0) == 0)
            {
                return default;
            };

            return ProcJudTrab[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista ProcJudTrab
        /// </summary>
        public int GetProcJudTrabCount => (ProcJudTrab != null ? ProcJudTrab.Count : 0);
#endif

        [XmlElement("infoMV")]
        public InfoMV InfoMV { get; set; }

        [XmlElement("procCS")]
        public ProcCS ProcCS { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.DmDev2299")]
    [ComVisible(true)]
#endif
    public class DmDev2299
    {
        [XmlElement("ideDmDev")]
        public string IdeDmDev { get; set; }

        [XmlElement("indRRA")]
        public string IndRRA { get; set; }

        [XmlElement("infoRRA")]
        public InfoRRA InfoRRA { get; set; }

        [XmlElement("infoPerApur")]
        public InfoPerApur2299 InfoPerApur { get; set; }

        [XmlElement("infoPerAnt")]
        public InfoPerAnt2299 InfoPerAnt { get; set; }

        #region ShouldSerialize

        public bool ShouldSerializeIndRRA() => !string.IsNullOrEmpty(IndRRA);

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoPerApur2299")]
    [ComVisible(true)]
#endif
    public class InfoPerApur2299
    {
        [XmlElement("ideEstabLot")]
        public List<IdeEstabLot2299> IdeEstabLot { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddIdeEstabLot(IdeEstabLot2299 item)
        {
            if (IdeEstabLot == null)
            {
                IdeEstabLot = new List<IdeEstabLot2299>();
            }

            IdeEstabLot.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista IdeEstabLot (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da IdeEstabLot</returns>
        public IdeEstabLot2299 GetDmDev(int index)
        {
            if ((IdeEstabLot?.Count ?? 0) == 0)
            {
                return default;
            };

            return IdeEstabLot[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista IdeEstabLot
        /// </summary>
        public int GetIdeEstabLotCount => (IdeEstabLot != null ? IdeEstabLot.Count : 0);
#endif
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.IdeEstabLot2299")]
    [ComVisible(true)]
#endif
    public class IdeEstabLot2299
    {
        [XmlElement("tpInsc")]
        public TpInsc TpInsc { get; set; }

        [XmlElement("nrInsc")]
        public string NrInsc { get; set; }

        [XmlElement("codLotacao")]
        public string Codlotacao { get; set; }

        [XmlElement("detVerbas")]
        public List<DetVerbas> DetVerbas { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddDetVerbas(DetVerbas item)
        {
            if (DetVerbas == null)
            {
                DetVerbas = new List<DetVerbas>();
            }

            DetVerbas.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista DetVerbas (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da DetVerbas</returns>
        public DetVerbas GetDetVerbas(int index)
        {
            if ((DetVerbas?.Count ?? 0) == 0)
            {
                return default;
            };

            return DetVerbas[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista DetVerbas
        /// </summary>
        public int GetDetVerbasCount => (DetVerbas != null ? DetVerbas.Count : 0);
#endif

        [XmlElement("infoAgNocivo")]
        public InfoAgNocivo2299 InfoAgNocivo { get; set; }

        [XmlElement("infoSimples")]
        public InfoSimples InfoSimples { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.DetVerbas")]
    [ComVisible(true)]
#endif
    public class DetVerbas
    {
        [XmlElement("codRubr")]
        public string CodRubr { get; set; }

        [XmlElement("ideTabRubr")]
        public string IdeTabRubr { get; set; }


        /// <summary>
        /// Informar a quantidade de referência para apuração (em horas, cotas, meses, etc.).
        /// Ex.: Quantidade de horas extras trabalhadas relacionada com uma rubrica de hora extra,
        /// quantidade de dias trabalhados relacionada com uma rubrica de salário, etc.
        /// Validação: Deve ser maior que 0 (zero).
        /// </summary>
        [XmlIgnore]
        public double QtdRubr { get; set; }

        [XmlElement("qtdRubr")]
        public string QtdRubrField
        {
            get => QtdRubr.ToString("F2", CultureInfo.InvariantCulture);
            set => QtdRubr = Converter.ToDouble(value);

        }

        /// <summary>
        /// Informar o fator, percentual, etc. da rubrica, quando necessário.
        /// Ex.: Adicional de horas extras 50%, relacionado a uma rubrica de horas extras: Fator = 50.
        /// Validação: Deve ser maior que 0 (zero).
        /// </summary>
        [XmlIgnore]
        public double FatorRubr { get; set; }

        [XmlElement("fatorRubr")]
        public string FatorRubrField
        {
            get => FatorRubr.ToString("F2", CultureInfo.InvariantCulture);
            set => FatorRubr = Converter.ToDouble(value);
        }

        #region ShouldSeriliaze

        public bool ShouldSeriliazeQtdRubrField() => QtdRubr > 0;
        public bool ShouldSerializeFatorRubrField() => FatorRubr > 0;

        #endregion ShouldSeriliaze

        /// <summary>
        /// Valor total da rubrica.
        /// Validação: Deve ser maior que 0 (zero).
        /// </summary>
        [XmlIgnore]
        public double VrRubr { get; set; }

        [XmlElement("vrRubr")]
        public string VrRubrField
        {
            get => VrRubr.ToString("F2", CultureInfo.InvariantCulture);
            set => VrRubr = Converter.ToDouble(value);

        }

        [XmlElement("indApurIR")]
        public IndApurIR IndApurIR { get; set; }

    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoAgNocivo2299")]
    [ComVisible(true)]
#endif
    public class InfoAgNocivo2299
    {
        [XmlElement("grauExp")]
        public string GrauExp { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoSimples")]
    [ComVisible(true)]
#endif
    public class InfoSimples
    {
        [XmlElement("indSimples")]
        public IndSimples IndSimples { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoPerAnt2299")]
    [ComVisible(true)]
#endif
    public class InfoPerAnt2299
    {
        [XmlElement("ideADC")]
        public List<IdeADC2299> IdeADC { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddIdeADC(IdeADC2299 item)
        {
            if (IdeADC == null)
            {
                IdeADC = new List<IdeADC2299>();
            }

            IdeADC.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista IdeADC (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da IdeADC</returns>
        public IdeADC2299 GetIdeADC(int index)
        {
            if ((IdeADC?.Count ?? 0) == 0)
            {
                return default;
            };

            return IdeADC[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista IdeADC
        /// </summary>
        public int GetIdeADCCount => (IdeADC != null ? IdeADC.Count : 0);
#endif
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.IdeADC2299")]
    [ComVisible(true)]
#endif
    public class IdeADC2299
    {
        [XmlIgnore]
#if INTEROP
        public DateTime DtAcConv { get; set; }
#else
        public DateTimeOffset DtAcConv { get; set; }
#endif

        [XmlElement("dtAcConv")]
        public string DtAcConvField
        {
            get => DtAcConv.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtAcConv = DateTime.Parse(value);
#else
            set => DtAcConv = DateTimeOffset.Parse(value);
#endif
        }

        [XmlElement("tpAcConv")]
        public string TpAcConv { get; set; }

        [XmlElement("dsc")]
        public string Dsc { get; set; }

        [XmlElement("idePeriodo")]
        public List<IdePeriodo2299> IdePeriodo { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddIdePeriodo(IdePeriodo2299 item)
        {
            if (IdePeriodo == null)
            {
                IdePeriodo = new List<IdePeriodo2299>();
            }

            IdePeriodo.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista IdePeriodo (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da IdePeriodo</returns>
        public IdePeriodo2299 GetIdePeriodo(int index)
        {
            if ((IdePeriodo?.Count ?? 0) == 0)
            {
                return default;
            };

            return IdePeriodo[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista IdePeriodo
        /// </summary>
        public int GetIdePeriodoCount => (IdePeriodo != null ? IdePeriodo.Count : 0);
#endif

        #region ShouldSerialize

        public bool ShouldSerializeDtAcConvField() => DtAcConv > DateTime.MinValue;

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.IdePeriodo2299")]
    [ComVisible(true)]
#endif
    public class IdePeriodo2299
    {
        [XmlIgnore]
#if INTEROP
        public DateTime PerRef { get; set; }
#else
        public DateTimeOffset PerRef { get; set; }
#endif

        [XmlElement("perRef")]
        public string PerRefField
        {
            get => PerRef.ToString("yyyy-MM");
#if INTEROP
            set => PerRef = DateTime.Parse(value);
#else
            set => PerRef = DateTimeOffset.Parse(value);
#endif
        }

        [XmlElement("ideEstabLot")]
        public List<IdeEstabLot2299> IdeEstabLot { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddIdeEstabLot(IdeEstabLot2299 item)
        {
            if (IdeEstabLot == null)
            {
                IdeEstabLot = new List<IdeEstabLot2299>();
            }

            IdeEstabLot.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista IdeEstabLot (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da IdeEstabLot</returns>
        public IdeEstabLot2299 GetIdeEstabLot(int index)
        {
            if ((IdeEstabLot?.Count ?? 0) == 0)
            {
                return default;
            };

            return IdeEstabLot[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista IdeEstabLot
        /// </summary>
        public int GetIdePeriodoCount => (IdeEstabLot != null ? IdeEstabLot.Count : 0);
#endif
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.ProcCS")]
    [ComVisible(true)]
#endif
    public class ProcCS
    {
        [XmlElement("nrProcJud")]
        public string NrProcJud { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.RemunAposDeslig")]
    [ComVisible(true)]
#endif
    public class RemunAposDeslig
    {
        [XmlElement("indRemun")]
#if INTEROP
        public IndRemun IndRemun { get; set; } = (IndRemun)(-1);
#else
        public IndRemun? IndRemun { get; set; }
#endif

        [XmlIgnore]
#if INTEROP
        public DateTime DtFimRemun { get; set; }
#else
        public DateTimeOffset DtFimRemun { get; set; }
#endif

        [XmlElement("dtFimRemun")]
        public string DtFimRemunField
        {
            get => DtFimRemun.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtFimRemun = DateTime.Parse(value);
#else
            set => DtFimRemun = DateTimeOffset.Parse(value);
#endif
        }

        #region ShouldSerialize

#if INTEROP
        public bool ShouldSerializeIndRemun() => IndRemun != (IndRemun)(-1);
#else
        public bool ShouldSerializeIndRemun() => IndRemun != null;
#endif

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.ConsigFGTS")]
    [ComVisible(true)]
#endif
    public class ConsigFGTS
    {
        [XmlElement("insConsig")]
        public string InsConsig { get; set; }

        [XmlElement("nrContr")]
        public string NrContr { get; set; }
    }
}

﻿#if INTEROP
using System.Runtime.InteropServices;
#endif
using System;
using Unimake.Business.DFe.Servicos.Interop;
using Unimake.Exceptions;
using Unimake.Business.DFe.Xml.DARE;

namespace Unimake.Business.DFe.Servicos.DARE
{
    /// <summary>
    /// Enviar o xml para o webservice
    /// </summary>
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Servicos.DARE.ReceitasDARE")]
    [ComVisible(true)]
#endif
    public class ReceitasDARE : ServicoBase, IInteropService<Unimake.Business.DFe.Xml.DARE.Receitas>
    {
        /// <summary>
        /// 
        /// </summary>
        public ReceitasDARE(Unimake.Business.DFe.Xml.DARE.Receitas consulta, Configuracao configuracao)
        {
            if (configuracao is null)
            {
                throw new ArgumentNullException(nameof(configuracao));
            }

            Inicializar(consulta?.GerarXML() ?? throw new ArgumentNullException(nameof(consulta)), configuracao);
        }

#if INTEROP
        /// <summary>
        /// Executa o serviço: envia o XML para o web-service
        /// </summary>
        /// <param name="receitasDARE">Objeto contendo o XML a ser enviado</param>
        /// <param name="configuracao"></param>
        /// <exception cref="NotImplementedException"></exception>
        [ComVisible(true)]
        public void Executar([MarshalAs(UnmanagedType.IUnknown)] Receitas receitasDARE, [MarshalAs(UnmanagedType.IUnknown)] Configuracao configuracao)
        {
            try
            {
                if (configuracao is null)
                {
                    throw new ArgumentNullException(nameof(configuracao));
                }

                Inicializar(receitasDARE?.GerarXML() ?? throw new ArgumentNullException(nameof(receitasDARE)), configuracao);
                Executar();
            }
            catch (ValidarXMLException ex)
            {
                Exceptions.ThrowHelper.Instance.Throw(ex);
            }
            catch (CertificadoDigitalException ex)
            {
                ThrowHelper.Instance.Throw(ex);
            }
            catch (Exception ex)
            {
                ThrowHelper.Instance.Throw(ex);
            }
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pasta"></param>
        /// <param name="nomeArquivo"></param>
        /// <param name="conteudoXML"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void GravarXmlDistribuicao(string pasta, string nomeArquivo, string conteudoXML)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        protected override void DefinirConfiguracao()
        {
            var xml = new Unimake.Business.DFe.Xml.DARE.Receitas();
            xml = xml.LerXML<Unimake.Business.DFe.Xml.DARE.Receitas>(ConteudoXML);

            if (!Configuracoes.Definida)
            {
                Configuracoes.Servico = Servico.DAREReceita;
                Configuracoes.CodigoUF = (int)UFBrasil.AN;

                base.DefinirConfiguracao();
            }
        }
    }
}


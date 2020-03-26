using System;
using System.Collections.Generic;
using System.Text;

namespace Ywferia.Cloud.Utilitarios.Enumerados
{
    #region Columnas    
     
    public enum ColumnasGrupoFuncional
    {
        Descripcion,
        Abreviatura,
        Codigo,
        SituacionRegistro,
        Tipo_Prestamo
    }

    public enum ColumnasGrupoSalarial
    {
        Descripcion,
        Codigo,
        SituacionRegistro
    }

    public enum ColumnasGradoSalarial
    {
        Codigo,
        Descripcion,
        Compania,
        MinimoSueldoTeorico,
        PromedioSueldoTeorico,
        MaximoSueldoTeorico,
        MinimoSueldoReal,
        PromedioSueldoReal,
        MaximoSueldoReal,
        MinimoSueldoMercado,
        PromedioSueldoMercado,
        MaximoSueldoMercado,
        SituacionRegistro,
        GrupoSalarial
    }

    public enum ColumnasPuestoCompania
    {
        Compania,
        Puesto,
        DescripcionPuesto,
        GrupoSalarial,
        FuncionesPuesto,
        CaracteristicasPuesto,
        GrupoFuncional,
        DescripcionGrupoFuncional,
        GradoSalarial,
        SituacionRegistro,
        PuestoWeb,
        Ocupacion
    }

    public enum ColumnasFormatosDocumentos
    {
        Compania,
        TipoDocumento,
        Ruta,
        GenerarInicio,
        SituacionRegistro
    }

    public enum ColumnasHabilidadPuesto
    {
        Habilidad,
        HabilidadDescripcion,
        Compania,
        Puesto,
        PuestoDescripcion,
        FechaRegistro,
        SituacionRegistro
    }

    public enum ColumnasTrabajadorBuscador
    {
        Matricula,
        Nombres,
        FechaIngrespCompania,
        UnidadFuncional,
        Ubicacion,
        Puesto,
        Centrocostos
    }

    public enum ColumnasImporte
    {
        CodigoConcepto,
        Descripcion,
        ImporteConcepto
    }

    #region ColumnaNacionalidad
    public enum ColumnaNacionalidad
    {
        Codigo,
        DescripcionNacionalidad,
        SituacionRegistro
    }
    #endregion

    #region ColumnaUbicacionFisica
    public enum ColumnaUbicacionFisica
    {
        Compañia,
        CodigoUbicacionFisica,
        DescripcionUbicacionFisica,
        SCTRPension,
        SCTRSalud,
        SituacionRegistro
    }
    #endregion

    #region ColumnaTurno
    public enum ColumnaTurno
    {
        CodigoTurno,
        DescripcionTurno,
        HoraIngreso,
        HoraToleranciaIngreso,
        HoraInicioRefrigerio,
        HoraTerminoRefrigerio,
        HoraSalida,
        SituacionRegistro
    }
    #endregion

    #region ColumnaTablaGeneral
    public enum ColumnaTablaGeneral
    {
        General,
        Descripción,
        SituacionRegistro
    }
    #endregion

    #region ColumnaMotivoAusencia
    public enum ColumnaMotivoAusencia
    {
        Código,
        Descripción,
        SituacionRegistro
    }
    #endregion

    #region ColumnaFeriado
    public enum ColumnaFeriado
    {
        FechaFeriado,
        MotivoFeriado,
        SituacionRegistro
    }
    #endregion

    #region ColumnaTipoFamilia
    public enum ColumnaTipoFamilia
    {
        TipoFamiliar,
        DescripcionFamiliar,
        ClaveSMF,
        SituacionRegistro
    }
    #endregion

    #region ColumnaTipoContrato
    public enum ColumnaTipoContrato
    {
        Compañia,
        TipoContrato,
        DescripcionContrato,
        SituacionRegistro
    }
    #endregion

    #region ColumnaTipoTrabajador
    public enum ColumnaTipoTrabajador
    {
        Compañia,
        Tipo,
        Descripción,
        SituacionRegistro
    }
    #endregion

    #region ColumnaMotivoCese
    public enum ColumnaMotivoCese
    {
        Código,
        Descripción,
        TextoLiquidacion,
        SituacionRegistro
    }
    #endregion

    #region ColumnaPendientesAsignacion

    public enum ColumnaPendientesAsignacion
    {
        UnidadFuncional,
        NombreUnidadFuncional,
        TipoUnidadFuncional,
        MatriculaResponsable,
        NombreMatriculaResponsable,
        UnidadFuncionalSuperior,
        DescripcionUnidadFuncionalSuperior,
        CodigoUbicacionFisica,
        NivelJerarquico,
        SituacionUnidadFuncional,
        Funciones,
        Orden,
        UnidadFuncionalDivision,
        UnidadFuncionalArea,
        UnidadFuncionalGcentral,
        CompetenciasFlagUnidades,
        OtraDescripcion,
        SupervisorResponsable,
        NombreSupervisorResponsable,
        CodigoSucursal,
        Compania,
        CentroCosto,
        SituacionRegistro,
        DescripcionUbicacionFisica,
        NombreCompleto,
        DescripcionCentroCostos
    }
    #endregion

    #region ColumnasUnidadFuncional
    public enum ColumnasUnidadFuncional
    {
        UnidadFuncionalCodigo,
        NombreUnidadFuncional,
        DescripcionCentroCostos,
        DescripcionUbicacionFisica,
        MatriculaResponsable,
        NombreMatriculaResponsable
    }
    #endregion

    #region ColumnasUtilidad
    //CORREGIR AQUI 20150718 HECHO EN CASA
    public enum ColumnasUtilidad
    {
        Matricula,
        ApellidoPaterno,
        FechaIngresoCompania,
        FechaRetiro,
        DiasTrabajados,
        SueldoBasico,
        ImporteFactor1,
        PorcentajeFactor1,
        ImporteFactor2,
        PorcentajeFactor2,
        UtilidadSinRemanente,
        Base18Sueldos,
        Tope18Sueldos,
        Utilidad18Sueldos,
        UtilidadRemanente,
        NombreCompleto
    }
    #endregion

    #region ColumnasJerarquiaUnidadFuncional
    public enum ColumnasJerarquiaUnidadFuncional
    {
        Compania,
        NivelJerarquico,
        DescripcionNivelJerarquico,
        DescripcionSituacion
    }
    #endregion

    #region ColumnasVacacionesGozadasDetalladoReporte
    public enum ColumnasVacacionesGozadasDetalladoReporte
    {
        FechaInicio,
        FechaFin,
        Nro_De_Dias
    }
    #endregion


    #region
    public enum ColumnasVacacionesGozadasReporte
    {
        Matricula,
        Trabajador,
        FechaIngreso,
        CentroCosto,
        UnidadFuncional,
        Gozadas
    }
    #endregion

    #region ColumnasVacacionesPendientesReporte
    public enum ColumnasVacacionesPendientesReporte
    {
        Matricula,
        Trabajador,
        FechaIngreso,
        CentroCosto,
        UnidadFuncional,
        Pendientes,
        Programadas,
        Saldo
    }
    #endregion

    #region ColumnasVacacionesProgramadasReporte
    public enum ColumnasVacacionesProgramadasReporte
    {
        Matricula,
        Trabajador,
        FechaIngreso,
        CentroCosto,
        UnidadFuncional,
        Programadas
    }
    #endregion

    #region ColumnasVacacionesTotalesReporte
    public enum ColumnasVacacionesTotalesReporte
    {
        Matricula,
        Trabajador,
        FechaIngreso,
        CentroCosto,
        UnidadFuncional,
        Vencidas,
        Pendientes,
        Truncas,
        Total,
        Programados,
        Saldo
    }
    #endregion

    #region ColumnasVacacionesValorizadasReporte
    public enum ColumnasVacacionesValorizadasReporte
    {
        Matricula,
        Trabajador,
        FechaIngreso,
        CentroCosto,
        UnidadFuncional,
        Vencidas,
        ValorVencidas,
        Pendientes,
        ValorPendientes,
        Truncas,
        ValorTruncas,
        ValorTotal
    }

    #endregion

    #region ColumnasVacacionesGeneralReporte
    public enum ColumnasVacacionesGeneralReporte
    {
        Matricula,
        Trabajador,
        UnidadFuncional,
        FechaInicio,
        FechaFin,
        NroDeDias
    }
    #endregion

    #endregion  //aqui

    #region Paginacion
    public enum TamanioPagina
    {
        Chico = 5,
        Normal = 10,
        Medio = 16,
        Grande = 24,
        ExtraGrande = 36,
        SuperGrande = 500
    }

    public enum DireccionOrden
    {
        Asc,
        Desc
    }

    public enum CambioDireccionOrden
    {
        Cambio,
        SinCambio
    }

    public enum AtributosPaginacion
    {
        DireccionOrden,
        HRef,
        OnClick,
        Orden,
        Pagina
    }
    #endregion

    #region Paginas
    public enum RespuestaMantenimiento
    {
        Inicial = -1,
        Cancelar = 0,
        Exito = 1,
        Error = 2,
        NoPermitido = 3,
        NoRegistros = 4
    }
    public enum AccionesMantenimiento
    {
        Nuevo = 1,
        Editar = 2,
        Consultar = 3,
        Imprimir = 4

    }

    public enum AccionesAsistenciaLicencia
    {
        Guardar = 1,
        Enviar = 2
    }
    #endregion    

    public enum Sexo
    {
        Masculino = 1,
        Femenino = 2
    }
    public enum EnumPadres
    {
        Padre = 1,
        Madre = 2,
        Todos = 0
    }
    public enum AccionesNoAuditables
    {
        Index,
        Editar,
        Nuevo,
        LogIn,
        LogOff,
        Error,
        ErrorLogin,
        Register,
        ObtenerCaptcha,
        //ExternalLogin,
        //ExternalLoginCallback,
        //ExternalLoginConfirmation,
        SignIn,
        ResetPassword, //JTELLO 2016.10.27 INICIO A04_0269
    }
    public enum AccionesPorDefecto
    {
        Index,
        Nuevo,
        Editar,
        Buscar,
        Eliminar,
        Exportar
    }
    public enum ControllerNoAuditables
    {
        Principal,
        Home,
        Account,
        Ubigeo
    }
    public enum TiposEventoAuditables
    {
        Accedio,
        ActivarDescativar,
        Actualizar,
        Adicionar,
        Anular,
        Aprobar,
        Consultar,
        Buscar,
        Detalle,
        Eliminar,
        Enviar,
        Exportar,
        Grabar,
        Modificar,
        Rechazar,
        Registrar,
    }
    public enum SiNo
    {
        Si = 1,
        No = 0
    }
    public enum SiNo2
    {
        Si = 1,
        No = 0
    }
    public enum EnumTipoUnidadFuncional
    {
        Unidad = 0,
        Area = 1,
        Sector = 2,
        Departamento = 3
    }
    public enum TiposModalidadIngreso
    {
        Conceptos = 1,
        Vistas = 2
    }
    public enum IndicadorGenerarUtilidad
    {
        Porcentaje = 0,
        MontoFijo = 1
    }

    public enum IndicadorPara
    {
        Conpensación = 1,
        Pago = 2
    }

    public enum TipoTrabajadorIndicador
    {
        Semanal = 1,
        Mensual = 0,
        Quincena = 2
    }
    public enum AsistenciaCriterio
    {
        Unidad = 1,
        Puesto = 2,
        TipoTrabajador = 3,
        UnidadFisica = 4,
        Contingencia = 5,
        Area = 6,
        Division = 7
    }
    public enum ConsultasWeb
    {
        TrabajadorConsultaCumpleanios,
        PrestamosConsulta,
        TrabajadorConsultaBoletas,
        ConfirmacionBoleta,
        TrabajadorConsultaOrganigrama
    }

    public enum EstadosSolicitudVacaciones
    {
        Registrando = 1,
        EnProceso = 2,
        Aprobado = 3,
        Rechazado = 4,
        Anulado = 5,
        AprobadoSup = 6
    }

    public enum AccionesFlujo
    {
        Aprobar = 1,
        Rechazar = 2,
        Anular = 3
    }

    public enum TipoUsuario
    {
        Sup = 0,
        Tra = 1,
    }

    public enum Niveles
    {
        NivelAdminitrador,
        NivelSupervisor,
        NivelTrabajador,
        NivelGerencia,
        NivelRRHH
    }

    public enum FormatosExcel
    {
        SinFormato = 0,
        Titulo = 1,
        Parametro = 2,
        Cabecera = 3,
        Detalle = 4,
        Fecha = 5
    }

    public enum EstadoRegistro
    {
        Activo = 1,
        Inactivo = 0
    }

    public enum TipoAutorizador
    {
        Trabajador = 1,
        UnidadFuncinal = 2,
        Puesto = 3
    }

    public enum TipoRenovacion
    {
        PorDuracion = 0,
        PorFechadeTermino = 1
    }

    public enum TipoDocumento
    {
        BoletaMensual = 1,
        CertificadoQuinta = 2,
        CertificadoCTS = 3,
        CertificadoUtilidades = 4,
        CertificadoAFP = 5,
        //ConstanciaTrab = 6,
        CertificadoTrabajo = 7,
        CertificadoQuintaCesados = 8,
        CartaRetiroCTS = 9,
        ConstanciaTrabajo = 6,
        CertificadoPracticasPreProf = 11,
        CertificadoPracticasProf = 12,
        ConstanciaPracticas = 13,
        CartaAperturaCTS = 14
    }

    #region Indicador

    public enum TipoGraficoIndicador
    {
        RotacionPersonal = 1,
        VariacionPlanilla = 2,
        Contratos = 3,
        VacacionesPendientes = 4,
        Asistencia = 5
    }

    #endregion

    #region Desempeño

    public enum OpcionDesempenio
    {
        Definicion = 7014,
        EvaluacionObjetivos = 7017,
        EvaluacionCompetencias = 7018
    }

    public enum TipoEvaluacion
    {
        Definicion = 1,
        EvaluacionObjetivos = 2,
        EvaluacionCompetencias = 3,
        EvaluacionGlobal = 4
    }

    public enum CorreoDesempenio
    {
        PendienteSimple = 5,
        AprobacionSimple = 6,
        RechazarSimple = 7,
        PendienteGlobal = 8,
        AprobacionGlobal = 9,
        RechazarGlobal = 10
    }

    #endregion

    #region Generales

    //public enum Aplicaciones
    //{
    //    Seguridad = 1,
    //    Asistencia = 4,
    //    Vacaciones = 5,
    //    ConsultasWeb = 6,
    //    Desempenio = 7,
    //    Reporteador = 21,
    //    Administracion = 31,
    //    Planilla = 32,
    //    Organización = 33,
    //    Puesto = 34,
    //    Parametro = 35,
    //    ActualizacionDatos = 36,
    //    Seleccion = 37,
    //    Indicadores = 50
    //}

    #endregion

    #region "Seleccion"
    public enum TipoCorreo
    {
        FlujoAprobacion = 1,
        AvisoAnalistaSeleccion = 2,
        RechazoFlujoAprobacion = 3,
        AprobacionFlujoAprobacion = 4,
        SeleccionAprobacion = 5,
        SeleccionRechazo = 6,
        EtapaFinalAprobacion = 7,
        ReqAprobacionIngreso = 8,
        ReqRechazoIngreso = 9,
        ReqAprobacionIngresoFinal = 10,
        ReqNuevoIngresoPersonal = 11,
        ReqModificacion = 12
    }
    #endregion

    #region "Gestion Movimiento Personal"
    public enum TipoSolicitud
    {
        Movimiento = 1,
        Cambio = 2,
        Dias = 3,
        Cese = 4,
        Distribucion = 5
    }
    #endregion
}
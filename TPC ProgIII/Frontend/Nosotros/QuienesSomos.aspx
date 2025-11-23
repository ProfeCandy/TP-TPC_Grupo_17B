<%@ Page Title="Quiénes Somos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuienesSomos.aspx.cs" Inherits="TPC_ProgIII.QuienesSomos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Hero Section -->
    <div class="bg-dark text-white py-5 mb-5">
        <div class="container">
            <h1 class="fw-bold display-4">Quiénes Somos</h1>
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Inicio.aspx" class="text-white-50 text-decoration-none">Inicio</a></li>
                    <li class="breadcrumb-item active text-white" aria-current="page">Quiénes Somos</li>
                </ol>
            </nav>
        </div>
    </div>

    <div class="container my-5">
        <div class="row align-items-center">
            <!-- Columna de Texto -->
            <div class="col-lg-6 pe-lg-5">
                <h6 class="text-danger fw-bold text-uppercase mb-2">Conocé nuestra historia</h6>
                <h1 class="fw-bold mb-4">¡Somos una empresa líder en venta de autopartes!</h1>
                
                <p class="text-secondary lh-lg" style="text-align: justify;">
                    Distryser nació en 1995 gracias a la oportunidad de emprender en Neuquén y fortalecer el crecimiento del rubro autopartista en la Patagonia. En nuestros inicios, fuimos una distribuidora de garaje atendida por dos personas, Diego el piloto y Luis su copiloto. Para 1998, nuestras energías nos llevaron a radicarnos en la calle Rio Negro 521, lugar que fue nuestra casa central hasta el 2008. Con la crisis del 2001 surgieron nuevos desafíos y tomamos la decisión de abrir nuestras puertas al público, para así llegar a más gente y ofrecer un servicio especializado al alcance de todos, así se sumó Soraya a la dirección de la contabilidad y administración y nuestro equipo comenzó a crecer. Hacia el 2003 abrimos nuestra sucursal en la ciudad vecina de Cipolletti y más colaboradores comenzaron a contagiarse de esta energía. Ya en 2008, mudamos nuestra casa central a Leguizamón 459 con más de 1000m2 de depósito, oficinas, salón comercial y área de despacho mayorista, en esta etapa crecimos mucho. Con los desafíos que trajo la pandemia, comenzamos a transitar el recambio generacional y se sumó Antonella a desarrollar espacios claves como redes sociales y sistema operativo. Nuestro equipo supera hoy en día las 20 personas y creemos que este es el camino. Proponernos desafíos, marcar una trayectoria y ser referentes regionales del rubro autopartista metalmecánico, es nuestra esencia, es eso que nos potencia y apasiona.
                </p>
            </div>

            <!-- Columna de Imágenes -->
            <div class="col-lg-6">
                <div class="d-flex flex-column gap-3">
                    <!-- Imagen 1: Logo -->
                    <!-- Nota: Reemplazar src con la ruta real de la imagen si es diferente -->
                    <img src="../assets/img/lg_distry/DISTRYSER_MARCA.png" class="img-fluid w-100 rounded" alt="Distryser Logo" onerror="this.onerror=null;this.src='https://placehold.co/600x200/FFC107/000?text=DISTRYSER+Logo';" />
                    
                    <!-- Imagen 2: Banner Suspensión -->
                    <img src="../assets/img/banner_suspension.png" class="img-fluid w-100 rounded" alt="Calidad Confianza Durabilidad" onerror="this.onerror=null;this.src='https://placehold.co/600x200/FFC107/000?text=Somos+Calidad+Confianza+Durabilidad';" />
                    
                    <!-- Imagen 3: Banner Contacto -->
                    <img src="../assets/img/banner_contacto.png" class="img-fluid w-100 rounded" alt="Información de Contacto" onerror="this.onerror=null;this.src='https://placehold.co/600x200/1a1a1a/FFF?text=Informacion+de+Contacto';" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

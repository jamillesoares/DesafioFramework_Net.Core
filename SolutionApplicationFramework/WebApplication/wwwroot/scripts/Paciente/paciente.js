$('#SelectPais').change(function () {
   
    var paisSelecionado = $('#SelectPais').val();
    $.ajax({
        url: "/pacientes/CarregaEstadoPais/",
        type: "POST",
        data: { "paisId": paisSelecionado },
        processData: true,
        success: function (response) {            
            var resultado = response;
            if (response.length > 0) {
                $('#SelectEstado').empty();
                $('#SelectEstado').append("<option value='' >Selecione</option>");
                $('#SelectCidade').empty();
                $('#SelectCidade').append("<option value='' >Selecione</option>");
                $(resultado).each(function () {
                    $('#SelectEstado').append("<option value='" + this.value + "'>" + this.text + "</option>");
                });
            }
            else {
                $('#SelectEstado').empty();
                $('#SelectEstado').append("<option value='' >Selecione</option>");
                $('#SelectCidade').empty();
                $('#SelectCidade').append("<option value='' >Selecione</option>");
                console.log("Estado não encontrado para o país selecionado.");
            }
        }
    });

});

$('#SelectEstado').change(function () {
    
    var estadoSelecionado = $('#SelectEstado').val();
    $.ajax({
        url: "/pacientes/CarregaCidadeEstado/",
        type: "POST",
        data: { "estadoId": estadoSelecionado },
        processData: true,
        success: function (response) {            
            var resultado = response;
            if (response.length > 0) {
                $('#SelectCidade').empty();
                $('#SelectCidade').append("<option value=''>Selecione</option>");
                $(resultado).each(function () {
                    $('#SelectCidade').append("<option value='" + this.value + "'>" + this.text + "</option>");
                });
            }
            else {
                $('#SelectCidade').empty();
                $('#SelectCidade').append("<option value=''>Selecione</option>");
                console.log("Cidade não encontrado para o estado selecionado.");
            }
        }
    });

});




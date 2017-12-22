$(document).ready(function () {
    $('#PerfilId').change(function () {
        perfilId = $('#PerfilId').prop('value');
        var url = '/Usuario/EditarPermissao?perfilId=' + perfilId
        window.location.href = url;
    });
});
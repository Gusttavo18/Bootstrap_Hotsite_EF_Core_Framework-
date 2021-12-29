function Cadastrar()
{
    let parametros = {
        Nome: $("#nome").val(),
        Email: $("#email").val(),
        Mensagem: $("#mensagem").val(),
    }
    $.post("/Home/Cadastrar", parametros)
    
    .done(function(data)
    {
        if (data.status=="OK") 
        {
            $("#form").after("<h3> Seu Cadastro foi registrado com sucesso!</h3>");
            $("#form").hide();
        } else {
            $("#form").after("<h3> Erro! Tente novamente mais tarde.</h3>");
            $("#form").hide();
        }    
    })
    .fail(function()
    {
        alert("Erro no servidor");
    });
}

$(document).ready(function()
{
    $("#frmCadastro").submit(function(e)
    {
        e.preventDefault();
        Cadastrar();
    });
});
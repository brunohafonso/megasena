//função que gera os jogos
function gerarJogos() {
  //limpando os jogos gerados anteriormente
  document.querySelector("#jogos").innerHTML = null;

  //montando objeto para enviar os dados
  var dados = {
    QuantidadeJogos: parseInt($("#quantidadeJogos").val()),
    QuantidadeNumeros: parseInt($("#quantidadeNumeros").val())
  };

  //metodo para envio dos dados de forma assincrona
  $.ajax({
    type: "POST",
    Accept: "application/json",
    contentType: "application/json",
    dataType: "json",
    url: "http://localhost:5000/api/megasena",
    data: JSON.stringify(dados),
    success: function(data) {
      //transformando retorno de json para objeto js
      var data = JSON.parse(data);
      var jogo = null;
      //se o retorno a operação de geração de jogos obtiver sucesso
      if (data.success == 1) {
        //montando os jogos na tela
        for (var i = 0; i < data.jogos.length; i++) {
          jogo = "<ul class='jogo'>";
          var numeros = data.jogos[i].split(" ");
          numeros.forEach(numero => {
            if (numero.length < 2) {
              jogo += "<li class='numero'>" + "0" + numero + "</li>";
            } else {
              jogo += "<li class='numero'>" + numero + "</li>";
            }
          });
          jogo += "</ul>";
          jogo += "<div class='divisor-jogo'></div>";
          //adicionando na tela
          $("#jogos").append(jogo);
        }
        //caso algo de errado aconteça é gerado um alert com a mensagem de erro
      } else {
        alert(data.responseText);
      }
    },
    error: function(data) {
        var data = JSON.parse(data);
        alert(data.responseText);
    }
  });
}

//evento de submit do botão do formulário
$("form").on("submit", function(e) {
  e.preventDefault();
  gerarJogos();
});

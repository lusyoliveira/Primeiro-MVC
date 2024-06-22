function selecionaTodos(el, name) {
    var itens = document.getElementsByName(name);
    for (var i = 0 ; i < itens.length; i++){
        itens[i].checked = el.checked;
    }
}
function editarCliente(Id) {
    window.location = "/Cliente/Editar/" + Id;
}
function ValidateInputRegistration() {
    if (document.getElementById('Name').value.length < 3) {
        alert('Por favor, preencha o campo Primeiro Nome');
        document.getElementById('Name').focus();
        return false
    }
    if (document.getElementById('Email').value.length < 3) {
        alert('Por favor, preencha o campo E-mail');
        document.getElementById('Email').focus();
        return false
    }
    if (document.getElementById('Password').value.length <= 0) {
        alert('Por favor, preencha o campo Senha');
        document.getElementById('Password').focus();
        return false
    }
    if (document.getElementById('Phone').value.length <= 0) {
        alert('Por favor, preencha o campo Telefone');
        document.getElementById('Phone').focus();
        return false
    }
}

function ValidateInputLogin() {
    if (document.getElementById('Email').value.length < 3) {
        alert('Por favor, preencha o campo E-mail');
        document.getElementById('Email').focus();
        return false
    }
    if (document.getElementById('Password').value.length <= 0) {
        alert('Por favor, preencha o campo Senha');
        document.getElementById('Password').focus();
        return false
    }
}

function CleanInputLogin() {
    document.getElementById('Email').value = '';
    document.getElementById('Password').value = '';
}
function ModalNotFound() {
    alert('Usuário não encontrado');
    return false
}
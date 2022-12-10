
async function Get(url, params = null) {
  
    let result;
    try {
      result = await $.ajax({
        url: url,
        type: "POST",
        data: params,
      });
      return result;
    } catch (error) {
      console.error(error);
    }
  }

  //ocultar elemento
function ocultarElemento(elemento, validar) {
  if (validar) {
    if (!$(elemento).hasClass("d-none")) {
      $(elemento).addClass("d-none");
    }
  } else {
    if ($(elemento).hasClass("d-none")) {
      $(elemento).removeClass("d-none");
    }
  }
}

//funcion para deshabilitar controles
function disabledControl(elemento, validar) {
  if (validar) {
    if (!elemento.hasAttribute("disabled")) {
      $(elemento).prop("disabled", true);
    }
  } else {
    if (elemento.hasAttribute("disabled")) {
      elemento.removeAttribute("disabled");
    }
  }
}

function readOnly(elemento, validar, val = false) {
  if (validar) {
    if (val) {
      if (!elemento.hasAttribute("readonly")) {
        $(elemento).attr("readonly", true);
      }
      return;
    }
    if (!elemento.hasAttribute("readonly")) {
      $(elemento).prop("readonly", true);
    }
  } else {
    if (elemento.hasAttribute("readonly")) {
      elemento.removeAttribute("readonly");
    }
  }
}

//reinicia los elementos de advertencia
function reiniciarElementos(elemento, span, val = false) {
  if (val) {
    if (elemento.hasClass("required-validate")) {
      elemento.removeClass("required-validate");
    }
    ocultarElemento(span, true);
    return;
  }
  if ($(elemento).hasClass("required-validate")) {
    $(elemento).removeClass("required-validate");
  }
  ocultarElemento(span, true);
}
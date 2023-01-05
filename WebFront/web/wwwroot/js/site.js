
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

function DataTableGenerico(idTabla, columnas, datos, target) {
  $(idTabla).DataTable({
    destroy: true,
    scrollX: true,
    lengthChange: true,
    lengthMenu: [5, 10, 20, 50, 100],
    paging: true,
    info: true,
    dom:
      "<'row'<'col-md-12'f><'col-md-12 text-end'<'d-flex align-items-center mt-1'<'col-md-10'l><'col-md-2'i>>>>" +
      "<'row'<'col-md-12'rt><'col-md-12 text-center'p>>",
    language: {
      lengthMenu: "Resultados pág. _MENU_",
      info: "_START_ al _TOTAL_ Resultados",
      search: "",
      searchPlaceholder: "Buscar",
      zeroRecords: "No se encontraron resultados",
      infoEmpty: "0 al 0 Resultados",
      paginate: {
        previous: "Anterior",
        next: "Siguiente",
      },
    },
    data: datos,
    columns: columnas,
    columnDefs: [
      {
        targets: target,
      },
    ],
  });
  agregarClasesDatatable(idTabla);
}

function agregarClasesDatatable(idTabla) {
  $(`${idTabla}_filter label`).addClass("col-md-12 label-datatable");
  $(`${idTabla}_filter input`).addClass("input-datatable");

  if ($(idTabla).find("tbody tr").length < 5) {
    $(`${idTabla}_paginate`).hide();
  } else {
    $(`${idTabla}_paginate`).show();
  }
}
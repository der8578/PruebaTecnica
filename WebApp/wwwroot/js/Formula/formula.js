const btnAgregar = document.getElementById("btn-Agregar");
const btnAgregarFormula = document.getElementById("btn-agregar-formula");

btnAgregar.addEventListener("click", function (e) {
  e.preventDefault();
  const selectElement = document.getElementById("idProductoItem");
  const idProductoItem = selectElement.value;
  const cantidadInput = document.getElementById("cantidadItem");
  const cantidadItem = cantidadInput.value;
  const selectedText = selectElement.options[selectElement.selectedIndex].text;

  const dataJson = {
    idproducto: idProductoItem,
    nombre: selectedText,
    cantidad: cantidadItem,
  };
  const data = JSON.stringify(dataJson);
  $.ajax({
    url: "/Formula/ValidItem",
    type: "POST",
    contentType: "application/json",
    data: data,
    success: function (response) {
      console.log(response);
      if (response.success) {
        console.log("Item agregado correctamente");
        $("#txt-errors").text("");
        addItems(dataJson);
        selectElement.value = "";
        cantidadInput.value = 0;
      } else {
        const mensajes = response.errors
          .map((err) => err.errormessage)
          .join("<br>");
        $("#txt-errors").html(mensajes);
      }
    },
    error: function (xhr, status, error) {
      console.error("Error en la petición AJAX:", error);
      $("#txt-errors").text("Error en el servidor.");
    },
  });
});

function addItems(data) {
  const hdnRowsCount = document.getElementById("hdnRowsCount");
  let index = hdnRowsCount.value;
  const tbody = document.querySelector("#materialesTable tbody");
  const template = `
            <tr>
                <td>
                    <input type="hidden" name="Materiales[${index}].IdProducto" value="${data.idproducto}" />
                    <input type="hidden" name="Materiales[${index}].Nombre" value="${data.nombre}" />
                    ${data.nombre}
                </td>
                <td>
                    <input type="hidden" name="Materiales[${index}].Cantidad" value="${data.cantidad}" />
                    ${data.cantidad}
                </td> 
                <td>
                    <button type="hidden" type="button" class="btn btn-danger btn-sm" onclick="eliminarFila(this)">Eliminar</button>
                </td>
            </tr>
        `;
  tbody.insertAdjacentHTML("beforeend", template);
  index++;
  hdnRowsCount.value = index;
}

window.onFailure = function (xhr) {
  let response = xhr.responseJSON || JSON.parse(xhr.responseText);
  let summary = document.getElementById("validation-summary");
  summary.innerHTML = "";
  if (response && response.errores) {
    response.errores.forEach(function (error) {
      error.mensajes.forEach(function (msg) {
        var div = document.createElement("div");
        div.textContent = msg;
        summary.appendChild(div);
      });
    });
  } else {
    summary.textContent = "Error inesperado.";
  }
};

window.eliminarFila = function (btn) {
  let fila = btn.closest("tr");
  fila.remove();
  reindexarFilas(); // Reindexamos después de eliminar
};

function reindexarFilas() {
  let filas = document.querySelectorAll("#materialesTable tbody tr");
  filas.forEach((fila, nuevoIndex) => {
    // Actualizamos los nombres de los inputs
    fila.querySelector(
      'input[name^="Materiales["][name$="].IdProducto"]'
    ).name = `Materiales[${nuevoIndex}].IdProducto`;
    fila.querySelector(
      'input[name^="Materiales["][name$="].Nombre"]'
    ).name = `Materiales[${nuevoIndex}].Nombre`;
    fila.querySelector(
      'input[name^="Materiales["][name$="].Cantidad"]'
    ).name = `Materiales[${nuevoIndex}].Cantidad`;
  });

  // Actualizamos el índice para nuevas filas
  document.getElementById("hdnRowsCount").value = filas.length;
}

window.onSuccessGrabar = function (response) {
  console.log(response);
  if (response.success) {
    alert("Registro grabado correctamente.");
    window.location.href = "/Formula";
  }
};

window.onSuccessModificar = function (response) {
  console.log(response);
  if (response.success) {
    alert("Registro modificado correctamente.");
    window.location.href = "/Formula";
  }
};

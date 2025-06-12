import { confirmFormValidation } from "../utils/form-validator.js";
const submitButton = document.getElementById("btn-crear");

submitButton.addEventListener("click", function (e) {
  if (!confirmFormValidation("save-form")) {
    e.preventDefault();
  }
});

window.onSuccessProducto = function (response) {
  if (response.success) {
    window.location.href = "/Producto";
  }
};

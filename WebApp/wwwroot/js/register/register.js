import { confirmFormValidation } from "../utils/form-validator.js";
const submitButton = document.getElementById("btn-crear");

submitButton.addEventListener("click", function (e) {
  if (!confirmFormValidation("save-form")) {
    e.preventDefault();
  }
});

window.onSuccessGrabar = function (response) {
  const errorMessage = document.getElementById("message-errors");
  if (response.success) {
    errorMessage.textContent = "";
    window.location.href = "/Usuarios";
  } else {
    errorMessage.textContent = response.message;
  }
};

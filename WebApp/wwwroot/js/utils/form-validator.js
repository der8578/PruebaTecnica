export function confirmFormValidation(formName) {
  const formObject = document.getElementById(formName);
  let $form = jQuery(formObject);
  $.validator.unobtrusive.parse($form);
  let resultado = $form.valid();
  return resultado;
}

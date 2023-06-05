using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.Panel.UI.ViewComponents
{
    public class ModalViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(string modalId, string headerText, string formId, string buttonText, string buttonClass, string detailDivId,string buttonType,string buttonOnclick)
        {
            ModalVCModel model = new ModalVCModel();
            model.ModalId = modalId;
            model.HeaderText = headerText;
            model.FormId = formId;
            model.ButtonText = buttonText;
            model.ButtonClass = buttonClass;
            model.DetailDivId = detailDivId;
            model.ButtonType = buttonType;
            model.ButtonOnclick = buttonOnclick;

            return View(model);
        }
    }
}


public class ModalVCModel
{
    public string ModalId { get; set; }
    public string HeaderText { get; set; }
    public string FormId { get; set; }
    public string ButtonText { get; set; }
    public string ButtonClass { get; set; }
    public string DetailDivId { get; set; }
    public string ButtonType { get; set; }
    public string ButtonOnclick { get; set; }
}
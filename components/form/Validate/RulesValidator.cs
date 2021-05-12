﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AntDesign.Internal
{
    public class RulesValidator : ComponentBase
    {
        private ValidationMessageStore _validationMessageStore;

        [CascadingParameter]
        internal EditContext EditContext { get; set; }

        protected override void OnInitialized()
        {
            _validationMessageStore = new ValidationMessageStore(EditContext);
        }

        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var err in errors)
            {
                _validationMessageStore.Add(EditContext.Field(err.Key), err.Value);
            }

            EditContext.NotifyValidationStateChanged();
        }

        public void ClearErrors()
        {
            _validationMessageStore.Clear();
            EditContext.NotifyValidationStateChanged();
        }
    }
}

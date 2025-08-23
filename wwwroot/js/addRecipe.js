document.addEventListener("DOMContentLoaded", function () {
    // ---------- Ingredients ----------
    const addIngredientSectionBtn = document.getElementById("add-ingredient-section");
    const ingredientsContainer = document.getElementById("ingredients-sections-container");
    const ingredientSubsectionTemplate = document.querySelector(".ingredient-subsection-template");
    const ingredientItemTemplate = document.querySelector(".ingredient-item-template");

    addIngredientSectionBtn.addEventListener("click", function () {
        const newSection = ingredientSubsectionTemplate.cloneNode(true);
        newSection.classList.remove("d-none");
        newSection.querySelectorAll("input, select, textarea").forEach(input => input.value = "");
        const itemsContainer = newSection.querySelector(".ingredient-items-container");

        // attach 'add ingredient item' button
        const addItemBtn = newSection.querySelector(".add-ingredient-item");
        addItemBtn.addEventListener("click", function () {
            const newItem = ingredientItemTemplate.cloneNode(true);
            newItem.classList.remove("d-none");
            newItem.querySelectorAll("input, select").forEach(input => input.value = "");
            itemsContainer.appendChild(newItem);
        });

        // add initial ingredient item automatically
        addItemBtn.click();

        ingredientsContainer.appendChild(newSection);
    });

    // ---------- Instructions ----------
    const addInstructionSectionBtn = document.getElementById("add-instruction-section");
    const instructionsContainer = document.getElementById("instructions-sections-container");
    const instructionSubsectionTemplate = document.querySelector(".instruction-subsection-template");
    const instructionStepTemplate = document.querySelector(".instruction-step-template");

    addInstructionSectionBtn.addEventListener("click", function () {
        const newSection = instructionSubsectionTemplate.cloneNode(true);
        newSection.classList.remove("d-none");
        newSection.querySelectorAll("input, textarea").forEach(input => input.value = "");
        const stepsContainer = newSection.querySelector(".instruction-steps-container");

        // attach 'add step' button
        const addStepBtn = newSection.querySelector(".add-instruction-step");
        addStepBtn.addEventListener("click", function () {
            const newStep = instructionStepTemplate.cloneNode(true);
            newStep.classList.remove("d-none");
            newStep.querySelectorAll("input, textarea").forEach(input => input.value = "");
            stepsContainer.appendChild(newStep);
        });

        // add initial instruction step automatically
        addStepBtn.click();

        instructionsContainer.appendChild(newSection);
    });

    // ---------- Category Selection ----------
    const select = document.getElementById('category-select');
    const newCatInput = document.getElementById('new-category-input');
    select.addEventListener('change', () => {
        newCatInput.classList.toggle('d-none', select.value !== 'new');
    });
});


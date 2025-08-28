document.addEventListener("DOMContentLoaded", function () {
    // ---------- Ingredients ----------
    const ingredientsContainer = document.getElementById("ingredients-sections-container");
    const firstIngredientItemsContainer = document.querySelector(".ingredient-items-container");
    const addIngredientSectionBtn = document.getElementById("add-ingredient-section");
    const addIngredientBtn = document.getElementById("add-ingredient-item");

    addIngredientBtn.addEventListener("click", function () {
        const itemIndex = firstIngredientItemsContainer.children.length;
        const newItem = document.createElement("div");
        newItem.classList.add("ingredient-item", "mb-2", "d-flex", "align-items-center");
        newItem.innerHTML = `
            <input type="number" name="Ingredients[0].Items[${itemIndex}].Quantity" placeholder="Quantity" class="form-control mb-1 me-2" style="flex: 1;" />
            <select name="Ingredients[0].Items[${itemIndex}].Unit" class="form-control mb-1" style="flex: 2;">
                <option value="">-- Select Unit --</option>
            </select>
            <input type="text" name="Ingredients[0].Items[${itemIndex}].IngredientName" placeholder="Ingredient Name" class="form-control mb-1 me-2" style="flex: 4;" />`;
        firstIngredientItemsContainer.appendChild(newItem);
    });
    addIngredientSectionBtn.addEventListener("click", function () {
        const sectionIndex = ingredientsContainer.children.length;
        const newSection = document.createElement("div");
        newSection.classList.add("ingredient-section");
        newSection.innerHTML = `
            <input type="text" name="Ingredients[${sectionIndex}].Section" placeholder="Section Label" class="form-control mb-2" />
            <div class="ingredient-items-container">
                <div class="ingredient-item mb-2 d-flex align-items-center">
                    <input type="number" name="Ingredients[${sectionIndex}].Items[0].Quantity" placeholder="Quantity" class="form-control mb-1 me-2" style="flex: 1;" />
                    <select name="Ingredients[${sectionIndex}].Items[0].Unit" class="form-control mb-1" style="flex: 2;">
                        <option value="">-- Select Unit --</option>
                    </select>
                    <input type="text" name="Ingredients[${sectionIndex}].Items[0].IngredientName" placeholder="Ingredient Name" class="form-control mb-1 me-2" style="flex: 4;" />
                </div>
            </div>
            <button type="button" class="btn btn-secondary add-ingredient-item">Add Ingredient</button>`;
        ingredientsContainer.appendChild(newSection);

        // Add functionality to the "Add Ingredient" button
        const addItemBtn = newSection.querySelector(".add-ingredient-item");
        const itemsContainer = newSection.querySelector(".ingredient-items-container");
        addItemBtn.addEventListener("click", function () {
            const itemIndex = itemsContainer.children.length;
            const newItem = document.createElement("div");
            newItem.classList.add("ingredient-item", "mb-2", "d-flex", "align-items-center");
            newItem.innerHTML = `
                <input type="number" name="Ingredients[${sectionIndex}].Items[${itemIndex}].Quantity" placeholder="Quantity" class="form-control mb-1 me-2" style="flex: 1;" />
                <select name="Ingredients[${sectionIndex}].Items[${itemIndex}].Unit" class="form-control mb-1" style="flex: 2;">
                    <option value="">-- Select Unit --</option>
                </select>
                <input type="text" name="Ingredients[${sectionIndex}].Items[${itemIndex}].IngredientName" placeholder="Ingredient Name" class="form-control mb-1 me-2" style="flex: 4;" />`;
            itemsContainer.appendChild(newItem);
        });
    });

    // ---------- Instructions ----------
    const instructionsContainer = document.getElementById("instructions-sections-container");
    const firstInstructionStepsContainer = document.querySelector(".instruction-items-container");
    const addInstructionSectionBtn = document.getElementById("add-instruction-section");
    const addInstructionBtn = document.getElementById("add-instruction-step");

    addInstructionBtn.addEventListener("click", function () {
        const stepIndex = firstInstructionStepsContainer.children.length;
        const newStep = document.createElement("div");
        newStep.classList.add("instruction-item", "mb-2");
        newStep.innerHTML = `
            <textarea name="Instructions[0].Steps[${stepIndex}].StepText" placeholder="Instruction Step" class="form-control mb-1"></textarea>`;
        firstInstructionStepsContainer.appendChild(newStep);
    });
    addInstructionSectionBtn.addEventListener("click", function () {
        const sectionIndex = instructionsContainer.children.length;
        const newSection = document.createElement("div");
        newSection.classList.add("instruction-section");
        newSection.innerHTML = `
            <input type="text" name="Instructions[${sectionIndex}].Section" placeholder="Section Label" class="form-control mb-2" />
            <div class="instruction-items-container">
                <div class="instruction-item mb-2">
                    <textarea name="Instructions[${sectionIndex}].Steps[0].StepText" placeholder="Instruction Step" class="form-control mb-1"></textarea>
                </div>
            </div>
            <button type="button" class="btn btn-secondary add-instruction-step">Add Step</button>`;
        instructionsContainer.appendChild(newSection);

        // Add functionality to the "Add Step" button
        const addStepBtn = newSection.querySelector(".add-instruction-step");
        const stepsContainer = newSection.querySelector(".instruction-items-container");
        addStepBtn.addEventListener("click", function () {
            const stepIndex = stepsContainer.children.length;
            const newStep = document.createElement("div");
            newStep.classList.add("instruction-item", "mb-2");
            newStep.innerHTML = `
                <textarea name="Instructions[${sectionIndex}].Steps[${stepIndex}].StepText" placeholder="Instruction Step" class="form-control mb-1"></textarea>`;
            stepsContainer.appendChild(newStep);
        });
    });
});
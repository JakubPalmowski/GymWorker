using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntityNamesAndPropertyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_Id_Trainer",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Addresses_Id_Address",
                table: "Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Diets_Diets_Id_Diet",
                table: "Meal_Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Diets_Meals_Id_Meal",
                table: "Meal_Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Users_Id_Mentor",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Users_Id_Pupil",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Mentor",
                table: "Pupil_mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Pupil",
                table: "Pupil_mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_exercises_Exercises_Id_Exercise",
                table: "Trainee_exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_exercises_Training_plans_Id_Training_plan",
                table: "Trainee_exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Gyms_Gyms_Id_Gym",
                table: "Trainer_Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Gyms_Users_Id_Trainer",
                table: "Trainer_Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_Id_Trainer",
                table: "Training_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Id_Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Training_plan_price_to",
                table: "Users",
                newName: "TrainingPlanPriceTo");

            migrationBuilder.RenameColumn(
                name: "Training_plan_price_from",
                table: "Users",
                newName: "TrainingPlanPriceFrom");

            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Personal_training_price_to",
                table: "Users",
                newName: "PersonalTrainingPriceTo");

            migrationBuilder.RenameColumn(
                name: "Personal_training_price_from",
                table: "Users",
                newName: "PersonalTrainingPriceFrom");

            migrationBuilder.RenameColumn(
                name: "Last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Id_Role",
                table: "Users",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "Email_validated",
                table: "Users",
                newName: "EmailValidated");

            migrationBuilder.RenameColumn(
                name: "Diet_price_to",
                table: "Users",
                newName: "DietPriceTo");

            migrationBuilder.RenameColumn(
                name: "Diet_price_from",
                table: "Users",
                newName: "DietPriceFrom");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "Users",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Id_Role",
                table: "Users",
                newName: "IX_Users_IdRole");

            migrationBuilder.RenameColumn(
                name: "Start_date",
                table: "Training_plans",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Plan_Duration",
                table: "Training_plans",
                newName: "PlanDuration");

            migrationBuilder.RenameColumn(
                name: "Id_Trainer",
                table: "Training_plans",
                newName: "IdTrainer");

            migrationBuilder.RenameColumn(
                name: "Id_Pupil",
                table: "Training_plans",
                newName: "IdPupil");

            migrationBuilder.RenameColumn(
                name: "End_date",
                table: "Training_plans",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Id_Training_plan",
                table: "Training_plans",
                newName: "IdTrainingPlan");

            migrationBuilder.RenameIndex(
                name: "IX_Training_plans_Id_Trainer",
                table: "Training_plans",
                newName: "IX_Training_plans_IdTrainer");

            migrationBuilder.RenameIndex(
                name: "IX_Training_plans_Id_Pupil",
                table: "Training_plans",
                newName: "IX_Training_plans_IdPupil");

            migrationBuilder.RenameColumn(
                name: "Id_Trainer_Gym",
                table: "Trainer_Gyms",
                newName: "IdTrainerGym");

            migrationBuilder.RenameColumn(
                name: "Id_Trainer",
                table: "Trainer_Gyms",
                newName: "IdTrainer");

            migrationBuilder.RenameColumn(
                name: "Id_Gym",
                table: "Trainer_Gyms",
                newName: "IdGym");

            migrationBuilder.RenameIndex(
                name: "IX_Trainer_Gyms_Id_Trainer",
                table: "Trainer_Gyms",
                newName: "IX_Trainer_Gyms_IdTrainer");

            migrationBuilder.RenameColumn(
                name: "Series_number",
                table: "Trainee_exercises",
                newName: "SeriesNumber");

            migrationBuilder.RenameColumn(
                name: "Repetitions_number",
                table: "Trainee_exercises",
                newName: "RepetitionsNumber");

            migrationBuilder.RenameColumn(
                name: "Id_Training_plan",
                table: "Trainee_exercises",
                newName: "IdTrainingPlan");

            migrationBuilder.RenameColumn(
                name: "Id_Exercise",
                table: "Trainee_exercises",
                newName: "IdExercise");

            migrationBuilder.RenameColumn(
                name: "Id_Trainee_exercise",
                table: "Trainee_exercises",
                newName: "IdTraineeExercise");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_exercises_Id_Training_plan",
                table: "Trainee_exercises",
                newName: "IX_Trainee_exercises_IdTrainingPlan");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_exercises_Id_Exercise",
                table: "Trainee_exercises",
                newName: "IX_Trainee_exercises_IdExercise");

            migrationBuilder.RenameColumn(
                name: "Id_Pupil",
                table: "Pupil_mentors",
                newName: "IdPupil");

            migrationBuilder.RenameColumn(
                name: "Id_Mentor",
                table: "Pupil_mentors",
                newName: "IdMentor");

            migrationBuilder.RenameIndex(
                name: "IX_Pupil_mentors_Id_Pupil",
                table: "Pupil_mentors",
                newName: "IX_Pupil_mentors_IdPupil");

            migrationBuilder.RenameColumn(
                name: "Opinion_date",
                table: "Opinions",
                newName: "OpinionDate");

            migrationBuilder.RenameColumn(
                name: "Id_Mentor",
                table: "Opinions",
                newName: "IdMentor");

            migrationBuilder.RenameColumn(
                name: "Id_Pupil",
                table: "Opinions",
                newName: "IdPupil");

            migrationBuilder.RenameIndex(
                name: "IX_Opinions_Id_Mentor",
                table: "Opinions",
                newName: "IX_Opinions_IdMentor");

            migrationBuilder.RenameColumn(
                name: "Id_Meal_Diet",
                table: "Meal_Diets",
                newName: "IdMealDiet");

            migrationBuilder.RenameColumn(
                name: "Id_Diet",
                table: "Meal_Diets",
                newName: "IdDiet");

            migrationBuilder.RenameColumn(
                name: "Id_Meal",
                table: "Meal_Diets",
                newName: "IdMeal");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_Diets_Id_Diet",
                table: "Meal_Diets",
                newName: "IX_Meal_Diets_IdDiet");

            migrationBuilder.RenameColumn(
                name: "Id_Address",
                table: "Gyms",
                newName: "IdAddress");

            migrationBuilder.RenameColumn(
                name: "Id_Gym",
                table: "Gyms",
                newName: "IdGym");

            migrationBuilder.RenameIndex(
                name: "IX_Gyms_Id_Address",
                table: "Gyms",
                newName: "IX_Gyms_IdAddress");

            migrationBuilder.RenameColumn(
                name: "Id_Trainer",
                table: "Exercises",
                newName: "IdTrainer");

            migrationBuilder.RenameColumn(
                name: "Exercise_steps",
                table: "Exercises",
                newName: "ExerciseSteps");

            migrationBuilder.RenameColumn(
                name: "Id_Exercise",
                table: "Exercises",
                newName: "IdExercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_Id_Trainer",
                table: "Exercises",
                newName: "IX_Exercises_IdTrainer");

            migrationBuilder.RenameColumn(
                name: "Postal_code",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Id_Address",
                table: "Addresses",
                newName: "IdAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_IdTrainer",
                table: "Exercises",
                column: "IdTrainer",
                principalTable: "Users",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_Addresses_IdAddress",
                table: "Gyms",
                column: "IdAddress",
                principalTable: "Addresses",
                principalColumn: "IdAddress",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Diets_Diets_IdDiet",
                table: "Meal_Diets",
                column: "IdDiet",
                principalTable: "Diets",
                principalColumn: "Id_Diet",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Diets_Meals_IdMeal",
                table: "Meal_Diets",
                column: "IdMeal",
                principalTable: "Meals",
                principalColumn: "Id_Meal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Users_IdMentor",
                table: "Opinions",
                column: "IdMentor",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Users_IdPupil",
                table: "Opinions",
                column: "IdPupil",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentors_Users_IdMentor",
                table: "Pupil_mentors",
                column: "IdMentor",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentors_Users_IdPupil",
                table: "Pupil_mentors",
                column: "IdPupil",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_exercises_Exercises_IdExercise",
                table: "Trainee_exercises",
                column: "IdExercise",
                principalTable: "Exercises",
                principalColumn: "IdExercise",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_exercises_Training_plans_IdTrainingPlan",
                table: "Trainee_exercises",
                column: "IdTrainingPlan",
                principalTable: "Training_plans",
                principalColumn: "IdTrainingPlan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Gyms_Gyms_IdGym",
                table: "Trainer_Gyms",
                column: "IdGym",
                principalTable: "Gyms",
                principalColumn: "IdGym",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Gyms_Users_IdTrainer",
                table: "Trainer_Gyms",
                column: "IdTrainer",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_IdPupil",
                table: "Training_plans",
                column: "IdPupil",
                principalTable: "Users",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_IdTrainer",
                table: "Training_plans",
                column: "IdTrainer",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_IdTrainer",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Gyms_Addresses_IdAddress",
                table: "Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Diets_Diets_IdDiet",
                table: "Meal_Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Diets_Meals_IdMeal",
                table: "Meal_Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Users_IdMentor",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Users_IdPupil",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentors_Users_IdMentor",
                table: "Pupil_mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentors_Users_IdPupil",
                table: "Pupil_mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_exercises_Exercises_IdExercise",
                table: "Trainee_exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_exercises_Training_plans_IdTrainingPlan",
                table: "Trainee_exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Gyms_Gyms_IdGym",
                table: "Trainer_Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Gyms_Users_IdTrainer",
                table: "Trainer_Gyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_IdPupil",
                table: "Training_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_IdTrainer",
                table: "Training_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TrainingPlanPriceTo",
                table: "Users",
                newName: "Training_plan_price_to");

            migrationBuilder.RenameColumn(
                name: "TrainingPlanPriceFrom",
                table: "Users",
                newName: "Training_plan_price_from");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "Phone_number");

            migrationBuilder.RenameColumn(
                name: "PersonalTrainingPriceTo",
                table: "Users",
                newName: "Personal_training_price_to");

            migrationBuilder.RenameColumn(
                name: "PersonalTrainingPriceFrom",
                table: "Users",
                newName: "Personal_training_price_from");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Last_name");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Users",
                newName: "Id_Role");

            migrationBuilder.RenameColumn(
                name: "EmailValidated",
                table: "Users",
                newName: "Email_validated");

            migrationBuilder.RenameColumn(
                name: "DietPriceTo",
                table: "Users",
                newName: "Diet_price_to");

            migrationBuilder.RenameColumn(
                name: "DietPriceFrom",
                table: "Users",
                newName: "Diet_price_from");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "Id_User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                newName: "IX_Users_Id_Role");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Training_plans",
                newName: "Start_date");

            migrationBuilder.RenameColumn(
                name: "PlanDuration",
                table: "Training_plans",
                newName: "Plan_Duration");

            migrationBuilder.RenameColumn(
                name: "IdTrainer",
                table: "Training_plans",
                newName: "Id_Trainer");

            migrationBuilder.RenameColumn(
                name: "IdPupil",
                table: "Training_plans",
                newName: "Id_Pupil");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Training_plans",
                newName: "End_date");

            migrationBuilder.RenameColumn(
                name: "IdTrainingPlan",
                table: "Training_plans",
                newName: "Id_Training_plan");

            migrationBuilder.RenameIndex(
                name: "IX_Training_plans_IdTrainer",
                table: "Training_plans",
                newName: "IX_Training_plans_Id_Trainer");

            migrationBuilder.RenameIndex(
                name: "IX_Training_plans_IdPupil",
                table: "Training_plans",
                newName: "IX_Training_plans_Id_Pupil");

            migrationBuilder.RenameColumn(
                name: "IdTrainerGym",
                table: "Trainer_Gyms",
                newName: "Id_Trainer_Gym");

            migrationBuilder.RenameColumn(
                name: "IdTrainer",
                table: "Trainer_Gyms",
                newName: "Id_Trainer");

            migrationBuilder.RenameColumn(
                name: "IdGym",
                table: "Trainer_Gyms",
                newName: "Id_Gym");

            migrationBuilder.RenameIndex(
                name: "IX_Trainer_Gyms_IdTrainer",
                table: "Trainer_Gyms",
                newName: "IX_Trainer_Gyms_Id_Trainer");

            migrationBuilder.RenameColumn(
                name: "SeriesNumber",
                table: "Trainee_exercises",
                newName: "Series_number");

            migrationBuilder.RenameColumn(
                name: "RepetitionsNumber",
                table: "Trainee_exercises",
                newName: "Repetitions_number");

            migrationBuilder.RenameColumn(
                name: "IdTrainingPlan",
                table: "Trainee_exercises",
                newName: "Id_Training_plan");

            migrationBuilder.RenameColumn(
                name: "IdExercise",
                table: "Trainee_exercises",
                newName: "Id_Exercise");

            migrationBuilder.RenameColumn(
                name: "IdTraineeExercise",
                table: "Trainee_exercises",
                newName: "Id_Trainee_exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_exercises_IdTrainingPlan",
                table: "Trainee_exercises",
                newName: "IX_Trainee_exercises_Id_Training_plan");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_exercises_IdExercise",
                table: "Trainee_exercises",
                newName: "IX_Trainee_exercises_Id_Exercise");

            migrationBuilder.RenameColumn(
                name: "IdPupil",
                table: "Pupil_mentors",
                newName: "Id_Pupil");

            migrationBuilder.RenameColumn(
                name: "IdMentor",
                table: "Pupil_mentors",
                newName: "Id_Mentor");

            migrationBuilder.RenameIndex(
                name: "IX_Pupil_mentors_IdPupil",
                table: "Pupil_mentors",
                newName: "IX_Pupil_mentors_Id_Pupil");

            migrationBuilder.RenameColumn(
                name: "OpinionDate",
                table: "Opinions",
                newName: "Opinion_date");

            migrationBuilder.RenameColumn(
                name: "IdMentor",
                table: "Opinions",
                newName: "Id_Mentor");

            migrationBuilder.RenameColumn(
                name: "IdPupil",
                table: "Opinions",
                newName: "Id_Pupil");

            migrationBuilder.RenameIndex(
                name: "IX_Opinions_IdMentor",
                table: "Opinions",
                newName: "IX_Opinions_Id_Mentor");

            migrationBuilder.RenameColumn(
                name: "IdMealDiet",
                table: "Meal_Diets",
                newName: "Id_Meal_Diet");

            migrationBuilder.RenameColumn(
                name: "IdDiet",
                table: "Meal_Diets",
                newName: "Id_Diet");

            migrationBuilder.RenameColumn(
                name: "IdMeal",
                table: "Meal_Diets",
                newName: "Id_Meal");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_Diets_IdDiet",
                table: "Meal_Diets",
                newName: "IX_Meal_Diets_Id_Diet");

            migrationBuilder.RenameColumn(
                name: "IdAddress",
                table: "Gyms",
                newName: "Id_Address");

            migrationBuilder.RenameColumn(
                name: "IdGym",
                table: "Gyms",
                newName: "Id_Gym");

            migrationBuilder.RenameIndex(
                name: "IX_Gyms_IdAddress",
                table: "Gyms",
                newName: "IX_Gyms_Id_Address");

            migrationBuilder.RenameColumn(
                name: "IdTrainer",
                table: "Exercises",
                newName: "Id_Trainer");

            migrationBuilder.RenameColumn(
                name: "ExerciseSteps",
                table: "Exercises",
                newName: "Exercise_steps");

            migrationBuilder.RenameColumn(
                name: "IdExercise",
                table: "Exercises",
                newName: "Id_Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_IdTrainer",
                table: "Exercises",
                newName: "IX_Exercises_Id_Trainer");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "Postal_code");

            migrationBuilder.RenameColumn(
                name: "IdAddress",
                table: "Addresses",
                newName: "Id_Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_Id_Trainer",
                table: "Exercises",
                column: "Id_Trainer",
                principalTable: "Users",
                principalColumn: "Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Gyms_Addresses_Id_Address",
                table: "Gyms",
                column: "Id_Address",
                principalTable: "Addresses",
                principalColumn: "Id_Address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Diets_Diets_Id_Diet",
                table: "Meal_Diets",
                column: "Id_Diet",
                principalTable: "Diets",
                principalColumn: "Id_Diet",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Diets_Meals_Id_Meal",
                table: "Meal_Diets",
                column: "Id_Meal",
                principalTable: "Meals",
                principalColumn: "Id_Meal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Users_Id_Mentor",
                table: "Opinions",
                column: "Id_Mentor",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Users_Id_Pupil",
                table: "Opinions",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Mentor",
                table: "Pupil_mentors",
                column: "Id_Mentor",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Pupil",
                table: "Pupil_mentors",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_exercises_Exercises_Id_Exercise",
                table: "Trainee_exercises",
                column: "Id_Exercise",
                principalTable: "Exercises",
                principalColumn: "Id_Exercise",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_exercises_Training_plans_Id_Training_plan",
                table: "Trainee_exercises",
                column: "Id_Training_plan",
                principalTable: "Training_plans",
                principalColumn: "Id_Training_plan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Gyms_Gyms_Id_Gym",
                table: "Trainer_Gyms",
                column: "Id_Gym",
                principalTable: "Gyms",
                principalColumn: "Id_Gym",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Gyms_Users_Id_Trainer",
                table: "Trainer_Gyms",
                column: "Id_Trainer",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_Id_Trainer",
                table: "Training_plans",
                column: "Id_Trainer",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Id_Role",
                table: "Users",
                column: "Id_Role",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

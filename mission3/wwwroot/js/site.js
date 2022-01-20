// Shad Baird
// Jan 19, 2022

//this function will fire whenever the page loads.
//because of the logic in checking if numbers are valid numbers, it will only produce a result when the form is valid
//so, combined with the model binding to the form, it should always be valid.

//however, the separation of duties is awful here. I would much rather write this all in c#, probably in a service, but at least in my controller.
$((e) => {
    
  //e.preventDefault();

  //* Weights
  let assignmentWeight = 0.55;
  let groupProjectWeight = 0.05;
  let quizWeight = 0.1;
  let examWeight = 0.2;
    let intexWeight = 0.1;

    //Grab the values from the form
    let assignments = $("form")[0].assignments.value;
    let groupProjects = $("form")[0].group_proj.value;
    let quizzes = $("form")[0].quiz.value;
    let exams = $("form")[0].exams.value;
    let intex = $("form")[0].intex.value;

    if (
        (assignments &&
        groupProjects &&
        quizzes &&
        exams &&
        intex) && 
        (
          assignments < 101 &&
          groupProjects < 101 &&
          quizzes < 101 &&
          exams < 101 &&
          intex < 101
        )
    ) {

        // Calculate the weighted scores
        let totalScore =
            assignmentWeight * assignments +
            groupProjectWeight * groupProjects +
            quizWeight * quizzes +
            examWeight * exams +
            intexWeight * intex;

        let letterGrade = generateLetterGrade(totalScore);

        let output = `${Math.floor(totalScore)}%  (${letterGrade})`;

        $("#output").text(output);
    }
    else {
        $("#output").text("");
    }
});


// Helper function to return the appropriate letter grade for a given score.
function generateLetterGrade(score) {
  let grade = "";
  if (score >= 94) {
    grade = "A";
  } else if (score >= 90) {
    grade = "A-";
  } else if (score >= 87) {
    grade = "B+";
  } else if (score >= 84) {
    grade = "B";
  } else if (score >= 80) {
    grade = "B-";
  } else if (score >= 77) {
    grade = "C+";
  } else if (score >= 74) {
    grade = "C";
  } else if (score >= 70) {
    grade = "C-";
  } else if (score >= 67) {
    grade = "D+";
  } else if (score >= 64) {
    grade = "D";
  } else if (score >= 60) {
    grade = "D-";
  } else {
    grade = "E";
  }
  console.log({ grade });
  return grade;
}

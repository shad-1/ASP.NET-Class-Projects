// Shad Baird
// Jan 12, 2022

$("form").submit((e) => {
  e.preventDefault();
  console.log({ e });

  //* Weights
  let assignmentWeight = 0.55;
  let groupProjectWeight = 0.05;
  let quizWeight = 0.1;
  let examWeight = 0.2;
  let intexWeight = 0.1;

  // Get the scores out of the event data.
  // I will apologize now for this repetitive code. I intend to go back and fix it, but I'm tight on time right now.
  let assignmentScore = isNaN(
    parseInt(e.currentTarget.elements.assignments.value)
  )
    ? 0
    : parseInt(e.currentTarget.elements.assignments.value);
  let groupProjectScore = isNaN(
    parseInt(e.currentTarget.elements.group_proj.value)
  )
    ? 0
    : parseInt(e.currentTarget.elements.group_proj.value);
  let quizScore = isNaN(parseInt(e.currentTarget.elements.quiz.value))
    ? 0
    : parseInt(e.currentTarget.elements.quiz.value);
  let examScore = isNaN(parseInt(e.currentTarget.elements.exams.value))
    ? 0
    : parseInt(e.currentTarget.elements.exams.value);
  let intexScore = isNaN(parseInt(e.currentTarget.elements.intex.value))
    ? 0
    : parseInt(e.currentTarget.elements.intex.value);

  // Calculate the weighted scores
  let totalScore =
    assignmentWeight * assignmentScore +
    groupProjectWeight * groupProjectScore +
    quizWeight * quizScore +
    examWeight * examScore +
    intexWeight * intexScore;

  let letterGrade = generateLetterGrade(totalScore);

  let output = `${Math.floor(totalScore)}%  (${letterGrade})`;

  $("#output").text(output);
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

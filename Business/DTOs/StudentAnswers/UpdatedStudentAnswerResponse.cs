﻿namespace Business.DTOs.StudentAnswers
{
    public class UpdatedStudentAnswerResponse
    {
        public Guid StudentAnswerId { get; set; }
        public Guid StudentId { get; set; }
        public Guid QuestionId { get; set; }
        public char SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }
}

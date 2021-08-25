﻿using System;
using System.Collections.Generic;

namespace Questionnaire.Core.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public QuestionChoiceType ChoiceType { get; set; }
    }
}

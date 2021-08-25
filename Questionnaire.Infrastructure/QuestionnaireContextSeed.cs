using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Questionnaire.Core.Entities;

namespace Questionnaire.Infrastructure
{
    // I think all the functions need's to be non static because you creating this class (instance)
    public class QuestionnaireContextSeed
    {
        public static async Task SeedAsync(QuestionnaireContext context, ILogger<QuestionnaireContextSeed> logger)
        {
            if (!context.Answers.Any())
            {
                 await context.AddRangeAsync(GetPreconfiguredQuestions());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(QuestionnaireContext).Name);
            }
        }

        private static IEnumerable<Question> GetPreconfiguredQuestions()
        {
            return new List<Question>
            {
                new Question()
                {
                    ChoiceType= QuestionChoiceType.SingleAnswer, QuestionText = "How often does the moon orbit the Earth?",
                        Answers = new List<Answer>
                        {
                            new Answer() { AnswerText = "every 7 days", Score = 0},
                            new Answer() { AnswerText = "every 27 days", Score = 100},
                            new Answer() { AnswerText = "every 365 days", Score = 50}
                        }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.MultiAnswers, QuestionText = "Which one of these characters are friends with Harry Potter?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "Ron Weasley", Score = 50},
                        new Answer() { AnswerText = "Draco Malfoy", Score = 0},
                        new Answer() { AnswerText = "Hermione Granger", Score = 50}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.MultiAnswers, QuestionText = "Which of the following are an international organisation?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "FBI", Score = 0},
                        new Answer() { AnswerText = "FIFA", Score = 30},
                        new Answer() { AnswerText = "NATO", Score = 70}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.MultiAnswers, QuestionText = "Which of the following actors was play James Bond?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "Sean Connery", Score = 30},
                        new Answer() { AnswerText = "Timothy Dalton", Score = 30},
                        new Answer() { AnswerText = "Roger Moore", Score = 40}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.SingleAnswer, QuestionText = "In which country is Transylvania?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "Bulgaria", Score = 10},
                        new Answer() { AnswerText = "Romania", Score = 100},
                        new Answer() { AnswerText = "Serbia", Score = 50}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.MultiAnswers, QuestionText = "The two biggest exporters of beers in Europe are?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "Germany", Score = 50},
                        new Answer() { AnswerText = "Belgium", Score = 50},
                        new Answer() { AnswerText = "Italy", Score = 0}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.SingleAnswer, QuestionText = "What does the term “SOS” commonly stand for?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "Save Our Ship", Score = 10},
                        new Answer() { AnswerText = "Save Our Souls", Score = 100},
                        new Answer() { AnswerText = "Save Our Seal", Score = 50}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.SingleAnswer, QuestionText = "Which company is known for publishing the Mario video game?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "Nintendo", Score = 100},
                        new Answer() { AnswerText = "SEGA", Score = 10},
                        new Answer() { AnswerText = "Electronic Arts", Score = 10}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.SingleAnswer, QuestionText = "How many time zones are there in total in the world?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "24", Score = 100},
                        new Answer() { AnswerText = "16", Score = 0},
                        new Answer() { AnswerText = "3", Score = 0}
                    }
                },
                new Question()
                {
                    ChoiceType= QuestionChoiceType.MultiAnswers, QuestionText = "Which of the following countries are in the Asian continent?",
                    Answers = new List<Answer>
                    {
                        new Answer() { AnswerText = "Japan", Score = 33},
                        new Answer() { AnswerText = "India", Score = 33},
                        new Answer() { AnswerText = "Afghanistan", Score = 34}
                    }
                },

            };
        }
    }
}

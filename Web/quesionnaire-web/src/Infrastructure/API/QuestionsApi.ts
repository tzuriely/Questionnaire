import { HttpClient } from "./HttpClient";  
import { Question } from '../../Domain/Entities/Question';
import { SelectedAnswers } from '../../Domain/SelectedAnswers/SelectedAnswers'
import { Result } from '../../Domain/Entities/Result';

export class QuestionsApi extends HttpClient {
    private static classInstance?: QuestionsApi;

    private constructor() {
        super('http://localhost:8081/api');
    }
  
    public static getInstance() {
      if (!this.classInstance) {
        this.classInstance = new QuestionsApi();
      }
  
      return this.classInstance;
    }

    public getQuestions = () => this.instance.get<Question[]>('/questions');

    public Calculate = (answers: SelectedAnswers[]) => {
      const toSend = {answersList: answers}
      return this.instance.post<Result>(`/answer`, toSend);
    }
}
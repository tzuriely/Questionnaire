export class SelectedAnswers {
    questionId: number;
    answers: number[]

    constructor(id: number) {
        this.questionId = id;
        this.answers = []
    }
    
}
using System;
using System.Runtime.CompilerServices;

string firstName;
var person = ValueTuple.Create("Kevin", "Arnold");

// 아래의 코드는 C# 9 이전에서는 컴파일 오류 발생
(firstName, string lastName) = person;

await GetSalaryAsync();

[System.Runtime.CompilerServices.AsyncMethodBuilder(typeof(System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder<>))]
async ValueTask<int> GetSalaryAsync()
{
    await Task.Delay(1000);
    return 60;
}
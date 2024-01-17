# CompanyClaims - a .NET Web API test example

## How to run
```powershell
Set-Location CompanyClaims.Api
dotnet run
```

## How to test
```powershell
Set-Location CompanyClaims.Api.Test
dotnet test
```

## Assumptions

There are some points in the Requirements and Database Structure that raise a number of questions.
In a real-life business scenario these points would be discussed and resolved with the client.
However, for the purposes of this exercise I have made several assumptions about the data, outlined below.

1. Claims.UCR
I will assume this stands for Unique Claim Reference or similar and that it is the primary identifier of a particular claim.

2. Claims.[Assured Name]
I will assume this is the full name of a person within the relevant Company that has made the claim.

3. ClaimType
Although present, this entire table appears to not be linked to any other tables in the schema. I will assume this is intentional.

4. Company.Active
The Company table includes data related to both companies and insurance policies. I will assume that the Company.Active column refers to the company itself.
I will further assume that for a company to have an active insurance policy, two things are needed: the company itself must be active and its insurance policy end date must be in the future.

5. Updating claims
I will assume that only the following properties on a claim may be updated using the claim update endpoint: LossDate, [Assured Name], [Incurred Loss] and Closed.
﻿; Unshipped analyzer release
; https://github.com/dotnet/roslyn-analyzers/blob/main/src/Microsoft.CodeAnalysis.Analyzers/ReleaseTrackingAnalyzers.Help.md

### New Rules
Rule ID | Category | Severity | Notes
--------|----------|----------|-------
CSLA0002 | Design | Warning | IsOperationMethodPublicAnalyzer
CSLA0003 | Usage | Error | CheckConstructorsAnalyzer
CSLA0004 | Usage | Warning | CheckConstructorsAnalyzer
CSLA0005 | Usage | Error | FindSaveAssignmentIssueAnalyzer
CSLA0006 | Usage | Error | FindSaveAssignmentIssueAnalyzer
CSLA0007 | Usage | Warning | EvaluatePropertiesForSimplicityAnalyzer
CSLA0008 | Usage | Error | EvaluateManagedBackingFieldsAnalyzer
CSLA0009 | Design | Warning | IsOperationMethodPublicAnalyzer
CSLA0010 | Design | Warning | FindOperationsWithNonSerializableArgumentsAnalyzer
CSLA0011 | Usage | Error | FindBusinessObjectCreationAnalyzer
CSLA0012 | Design | Error | FindOperationsWithIncorrectReturnTypesAnalyzer
CSLA0013 | Usage | Warning | DoesChildOperationHaveRunLocalAnalyzer
CSLA0014 | Usage | Info | DoesOperationHaveAttributeAnalyzer
CSLA0015 | Usage | Error | EvaluateOperationAttributeUsageAnalyzer
CSLA0016 | Usage | Error | AsynchronousBusinessRuleInheritingFromBusinessRuleAnalyzer
CSLA0017 | Usage | Warning | BusinessRuleDoesNotUseAddMethodsOnContextAnalyzer
CSLA0018 | Usage | Error | IsCompleteCalledInAsynchronousBusinessRuleAnalyzer
CSLA0019 | Usage | Error | FindRefAndOutParametersInOperationsAnalyzer
CSLA0020 | Usage | Warning | ObjectAuthorizationRulesAttributeMissing
CSLA0021 | Usage | Info | ObjectAuthorizationRulesPublic
CSLA0022 | Usage | Warning | ObjectAuthorizationRulesStatic
CSLA0023 | Refactoring | Info | EvaluateManagedBackingFieldsNameofAnalyzer
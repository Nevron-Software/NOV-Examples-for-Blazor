#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
241,
247,
248,
249,
250,
251,
252,
253,
254,
256,
257,
321,
322,
324,
347,
348,
349,
360,
361,
362,
363,
442,
443,
444,
447,
481,
482,
484,
486,
488,
490,
495,
503,
504,
505,
506,
507,
508,
509,
510,
511,
512,
513,
514,
515,
516,
517,
518,
519,
641,
649,
652,
654,
660,
661,
663,
664,
668,
671,
672,
674,
675,
678,
679,
680,
683,
685,
688,
690,
692,
761,
763,
765,
774,
775,
776,
777,
779,
786,
787,
788,
789,
790,
798,
799,
800,
804,
805,
808,
810,
1025,
1204,
1205,
5571,
5572,
5574,
5575,
5576,
5577,
5578,
5580,
5582,
5584,
5585,
5586,
5594,
5596,
5600,
5601,
5603,
5605,
5607,
5619,
5626,
5632,
5633,
5635,
5636,
5637,
5638,
5639,
5641,
5643,
6599,
6603,
6605,
6606,
6607,
6608,
6717,
6718,
6719,
6720,
6738,
6739,
6740,
6742,
6744,
6788,
6844,
6855,
6856,
6857,
7154,
7155,
7159,
7160,
7189,
7207,
7213,
7220,
7230,
7233,
7309,
7319,
7321,
7322,
7323,
7330,
7343,
7363,
7364,
7372,
7374,
7381,
7382,
7385,
7387,
7392,
7398,
7399,
7406,
7408,
7420,
7423,
7424,
7425,
7436,
7445,
7451,
7452,
7453,
7455,
7456,
7474,
7476,
7490,
7512,
7513,
7533,
7563,
7564,
7956,
8092,
8275,
8276,
8280,
8283,
8337,
8843,
8844,
9389,
9390,
9391,
9989,
10010,
10017,
10019,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementType_raw (int,int);
int ves_icall_System_Array_IsValueOfElementType_raw (int,int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy_raw (int,int,int,int,int,int);
int ves_icall_System_Array_GetLength_raw (int,int,int);
int ves_icall_System_Array_GetLowerBound_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
int ves_icall_System_Array_GetValueImpl_raw (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
int ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
void ves_icall_System_Enum_InternalBoxEnum_raw (int,int,int64_t,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Acos (double);
double ves_icall_System_Math_Asin (double);
double ves_icall_System_Math_Atan (double);
double ves_icall_System_Math_Atan2 (double,double);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Cosh (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Log (double);
double ves_icall_System_Math_Log10 (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sinh (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Tanh (double);
double ves_icall_System_Math_ModF (double,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
void ves_icall_RuntimeType_GetPacking_raw (int,int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsComObject_raw (int,int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Read_Long (int);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
int64_t ves_icall_System_Threading_Interlocked_Add_Long (int,int64_t);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_test_synchronised_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
int ves_icall_System_Threading_Thread_GetCurrentProcessorNumber_raw (int);
void ves_icall_System_Threading_Thread_StartInternal_raw (int,int,int);
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
void ves_icall_System_Runtime_InteropServices_Marshal_GetDelegateForFunctionPointerInternal_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int mono_object_hash_icall_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw (int,int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_Debugger_IsLogging ();
void ves_icall_System_Diagnostics_Debugger_Log (int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 241,
ves_icall_System_Array_InternalCreate,
// token 247,
ves_icall_System_Array_GetCorElementTypeOfElementType_raw,
// token 248,
ves_icall_System_Array_IsValueOfElementType_raw,
// token 249,
ves_icall_System_Array_CanChangePrimitive,
// token 250,
ves_icall_System_Array_FastCopy_raw,
// token 251,
ves_icall_System_Array_GetLength_raw,
// token 252,
ves_icall_System_Array_GetLowerBound_raw,
// token 253,
ves_icall_System_Array_GetGenericValue_icall,
// token 254,
ves_icall_System_Array_GetValueImpl_raw,
// token 256,
ves_icall_System_Array_SetValueImpl_raw,
// token 257,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 321,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 322,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 324,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 347,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 348,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 349,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 360,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 361,
ves_icall_System_Enum_InternalBoxEnum_raw,
// token 362,
ves_icall_System_Enum_InternalGetCorElementType,
// token 363,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 442,
ves_icall_System_Environment_get_ProcessorCount,
// token 443,
ves_icall_System_Environment_get_TickCount,
// token 444,
ves_icall_System_Environment_get_TickCount64,
// token 447,
ves_icall_System_Environment_FailFast_raw,
// token 481,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 482,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 484,
ves_icall_System_GC_SuppressFinalize_raw,
// token 486,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 488,
ves_icall_System_GC_GetGCMemoryInfo,
// token 490,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 495,
ves_icall_System_Object_MemberwiseClone_raw,
// token 503,
ves_icall_System_Math_Acos,
// token 504,
ves_icall_System_Math_Asin,
// token 505,
ves_icall_System_Math_Atan,
// token 506,
ves_icall_System_Math_Atan2,
// token 507,
ves_icall_System_Math_Ceiling,
// token 508,
ves_icall_System_Math_Cos,
// token 509,
ves_icall_System_Math_Cosh,
// token 510,
ves_icall_System_Math_Floor,
// token 511,
ves_icall_System_Math_Log,
// token 512,
ves_icall_System_Math_Log10,
// token 513,
ves_icall_System_Math_Pow,
// token 514,
ves_icall_System_Math_Sin,
// token 515,
ves_icall_System_Math_Sinh,
// token 516,
ves_icall_System_Math_Sqrt,
// token 517,
ves_icall_System_Math_Tan,
// token 518,
ves_icall_System_Math_Tanh,
// token 519,
ves_icall_System_Math_ModF,
// token 641,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 649,
ves_icall_RuntimeType_make_array_type_raw,
// token 652,
ves_icall_RuntimeType_make_byref_type_raw,
// token 654,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 660,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 661,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 663,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 664,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 668,
ves_icall_RuntimeType_GetPacking_raw,
// token 671,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 672,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 674,
ves_icall_System_RuntimeType_getFullName_raw,
// token 675,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 678,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 679,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 680,
ves_icall_RuntimeType_GetFields_native_raw,
// token 683,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 685,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 688,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 690,
ves_icall_RuntimeType_GetName_raw,
// token 692,
ves_icall_RuntimeType_GetNamespace_raw,
// token 761,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 763,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 765,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 774,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 775,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 776,
ves_icall_RuntimeTypeHandle_IsComObject_raw,
// token 777,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 779,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 786,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 787,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 788,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 789,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 790,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 798,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 799,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 800,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 804,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 805,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 808,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 810,
ves_icall_System_String_FastAllocateString_raw,
// token 1025,
ves_icall_System_Type_internal_from_handle_raw,
// token 1204,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1205,
ves_icall_System_ValueType_Equals_raw,
// token 5571,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 5572,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 5574,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 5575,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 5576,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 5577,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 5578,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 5580,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 5582,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 5584,
ves_icall_System_Threading_Interlocked_Read_Long,
// token 5585,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 5586,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 5594,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 5596,
mono_monitor_exit_icall_raw,
// token 5600,
ves_icall_System_Threading_Monitor_Monitor_test_synchronised_raw,
// token 5601,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 5603,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 5605,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 5607,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 5619,
ves_icall_System_Threading_Thread_GetCurrentProcessorNumber_raw,
// token 5626,
ves_icall_System_Threading_Thread_StartInternal_raw,
// token 5632,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 5633,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 5635,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 5636,
ves_icall_System_Threading_Thread_GetState_raw,
// token 5637,
ves_icall_System_Threading_Thread_SetState_raw,
// token 5638,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 5639,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 5641,
ves_icall_System_Threading_Thread_YieldInternal,
// token 5643,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 6599,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 6603,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 6605,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 6606,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 6607,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 6608,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 6717,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 6718,
ves_icall_System_GCHandle_InternalFree_raw,
// token 6719,
ves_icall_System_GCHandle_InternalGet_raw,
// token 6720,
ves_icall_System_GCHandle_InternalSet_raw,
// token 6738,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 6739,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 6740,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 6742,
ves_icall_System_Runtime_InteropServices_Marshal_GetDelegateForFunctionPointerInternal_raw,
// token 6744,
ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw,
// token 6788,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 6844,
mono_object_hash_icall_raw,
// token 6855,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 6856,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 6857,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 7154,
ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw,
// token 7155,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 7159,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 7160,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 7189,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 7207,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 7213,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 7220,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 7230,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 7233,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 7309,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 7319,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 7321,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 7322,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 7323,
ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw,
// token 7330,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 7343,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 7363,
ves_icall_reflection_get_token_raw,
// token 7364,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 7372,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 7374,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 7381,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 7382,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 7385,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 7387,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 7392,
ves_icall_reflection_get_token_raw,
// token 7398,
ves_icall_get_method_info_raw,
// token 7399,
ves_icall_get_method_attributes,
// token 7406,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 7408,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 7420,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 7423,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 7424,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 7425,
ves_icall_reflection_get_token_raw,
// token 7436,
ves_icall_InternalInvoke_raw,
// token 7445,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 7451,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 7452,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 7453,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 7455,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 7456,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 7474,
ves_icall_InvokeClassConstructor_raw,
// token 7476,
ves_icall_InternalInvoke_raw,
// token 7490,
ves_icall_reflection_get_token_raw,
// token 7512,
ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw,
// token 7513,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 7533,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 7563,
ves_icall_reflection_get_token_raw,
// token 7564,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 7956,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 8092,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 8275,
ves_icall_ModuleBuilder_basic_init_raw,
// token 8276,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 8280,
ves_icall_ModuleBuilder_getToken_raw,
// token 8283,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 8337,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 8843,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 8844,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 9389,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 9390,
ves_icall_System_Diagnostics_Debugger_IsLogging,
// token 9391,
ves_icall_System_Diagnostics_Debugger_Log,
// token 9989,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 10010,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 10017,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 10019,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_handles [] = {
0,
1,
1,
0,
1,
1,
1,
0,
1,
1,
1,
0,
0,
0,
1,
1,
1,
1,
1,
0,
1,
0,
0,
0,
1,
1,
1,
1,
1,
0,
1,
1,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
0,
1,
1,
1,
1,
1,
1,
1,
0,
1,
1,
0,
0,
1,
1,
1,
1,
1,
1,
1,
1,
1,
0,
1,
1,
1,
1,
1,
1,
1,
1,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
0,
1,
1,
1,
1,
1,
0,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
0,
0,
1,
1,
1,
1,
1,
1,
1,
0,
1,
1,
1,
1,
0,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
0,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
1,
0,
0,
0,
0,
0,
0,
0,
};

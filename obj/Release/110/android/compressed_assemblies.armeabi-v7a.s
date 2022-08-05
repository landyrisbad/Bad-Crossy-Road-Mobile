	.arch	armv7-a
	.syntax unified
	.eabi_attribute 67, "2.09"	@ Tag_conformance
	.eabi_attribute 6, 10	@ Tag_CPU_arch
	.eabi_attribute 7, 65	@ Tag_CPU_arch_profile
	.eabi_attribute 8, 1	@ Tag_ARM_ISA_use
	.eabi_attribute 9, 2	@ Tag_THUMB_ISA_use
	.fpu	vfpv3-d16
	.eabi_attribute 34, 1	@ Tag_CPU_unaligned_access
	.eabi_attribute 15, 1	@ Tag_ABI_PCS_RW_data
	.eabi_attribute 16, 1	@ Tag_ABI_PCS_RO_data
	.eabi_attribute 17, 2	@ Tag_ABI_PCS_GOT_use
	.eabi_attribute 20, 2	@ Tag_ABI_FP_denormal
	.eabi_attribute 21, 0	@ Tag_ABI_FP_exceptions
	.eabi_attribute 23, 3	@ Tag_ABI_FP_number_model
	.eabi_attribute 24, 1	@ Tag_ABI_align_needed
	.eabi_attribute 25, 1	@ Tag_ABI_align_preserved
	.eabi_attribute 38, 1	@ Tag_ABI_FP_16bit_format
	.eabi_attribute 18, 4	@ Tag_ABI_PCS_wchar_t
	.eabi_attribute 26, 2	@ Tag_ABI_enum_size
	.eabi_attribute 14, 0	@ Tag_ABI_PCS_R9_use
	.file	"compressed_assemblies.armeabi-v7a.armeabi-v7a.s"
	.include	"compressed_assemblies.armeabi-v7a-data.inc"

	.section	.data.compressed_assembly_descriptors,"aw",%progbits
	.type	.L.compressed_assembly_descriptors, %object
	.p2align	2
.L.compressed_assembly_descriptors:
	/* 0: Java.Interop.dll */
	/* uncompressed_file_size */
	.long	162304
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_0

	/* 1: Mono.Android.dll */
	/* uncompressed_file_size */
	.long	1122816
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_1

	/* 2: Mono.Security.dll */
	/* uncompressed_file_size */
	.long	109568
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_2

	/* 3: MonoGame.Framework.dll */
	/* uncompressed_file_size */
	.long	1079296
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_3

	/* 4: Shit Crossy Road.dll */
	/* uncompressed_file_size */
	.long	19456
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_4

	/* 5: System.Core.dll */
	/* uncompressed_file_size */
	.long	58368
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_5

	/* 6: System.Drawing.Common.dll */
	/* uncompressed_file_size */
	.long	9216
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_6

	/* 7: System.Net.Http.dll */
	/* uncompressed_file_size */
	.long	212992
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_7

	/* 8: System.Numerics.dll */
	/* uncompressed_file_size */
	.long	25600
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_8

	/* 9: System.Runtime.Serialization.dll */
	/* uncompressed_file_size */
	.long	5632
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_9

	/* 10: System.dll */
	/* uncompressed_file_size */
	.long	580096
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_10

	/* 11: mscorlib.dll */
	/* uncompressed_file_size */
	.long	1963520
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_11

	.size	.L.compressed_assembly_descriptors, 144
	.section	.data.compressed_assemblies,"aw",%progbits
	.type	compressed_assemblies, %object
	.p2align	2
	.global	compressed_assemblies
compressed_assemblies:
	/* count */
	.long	12
	/* descriptors */
	.long	.L.compressed_assembly_descriptors
	.size	compressed_assemblies, 8

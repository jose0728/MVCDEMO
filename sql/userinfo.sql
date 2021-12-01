/*
 Navicat Premium Data Transfer

 Source Server         : 192.168.33.128
 Source Server Type    : MySQL
 Source Server Version : 50735
 Source Host           : 192.168.33.128:3306
 Source Schema         : demo

 Target Server Type    : MySQL
 Target Server Version : 50735
 File Encoding         : 65001

 Date: 15/11/2021 14:11:11
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for userinfo
-- ----------------------------
DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE `userinfo`  (
  `Id` bigint(20) NOT NULL,
  `EnterpriseId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `UserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `UnionId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Position` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Active` tinyint(1) DEFAULT NULL,
  `IsHide` tinyint(1) DEFAULT NULL,
  `IsLeaderInDepts` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `IsSenior` tinyint(1) DEFAULT NULL,
  `Avatar` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Jobnumber` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `HiredDate` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `AddTime` datetime(0) DEFAULT NULL,
  `UpdateTime` datetime(0) DEFAULT NULL,
  `Dr` smallint(6) DEFAULT NULL,
  `Ts` datetime(0) DEFAULT NULL,
  `IsAdmin` tinyint(1) DEFAULT NULL,
  `IsBoss` tinyint(1) DEFAULT NULL,
  `UserType` smallint(6) NOT NULL DEFAULT 0 COMMENT '用户类型：0企业员工 1外部联系人',
  `OAUserId` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `idx_EnterpriseId_Dr_Id_UserId`(`EnterpriseId`, `Dr`, `Id`, `UserId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
